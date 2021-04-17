using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Lovelace.Core.Entities.Base.Entity;
using Lovelace.Core.Interfaces.Base;
using Lovelace.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lovelace.Data.Repository.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        private bool _disposed;
        protected readonly Contexto Context;
        private DbSet<T> Entities { get; set; }

      public BaseRepository(Contexto contexto)
        {
            Context = contexto;
            Entities = contexto.Set<T>();
        }

        private IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            var query = Entities.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                    if (include != null)
                        query = query.Include(include);
            }
            return query;
        }

        public T Get(Expression<Func<T, bool>> filters, string thenIncludes = "", params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (thenIncludes.Equals("All"))
            {
                query = this.AddDefaultIncludes(query);
            }

            if (filters != null)
                return query.Where(filters).SingleOrDefault();

            return query.SingleOrDefault();
        }

        public T GetById(long Id, params Expression<Func<T, object>>[] includes)
        {
            return Query(includes).SingleOrDefault(i => i.Id.Equals(Id));
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filters = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                query = query.Where(filters);

            return query;
        }

        public virtual IQueryable<T> AddDefaultIncludes(IQueryable<T> query)
        {
            return query;
        }

        public List<T> GetAll(Expression<Func<T, bool>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                query = query.Where(filters);

            if (sortedBy != null)
                query = sortedBy(query);

            return query.ToList();
        }
        
        public T Add(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(typeof(T).FullName);

            var retorno = Entities.Add(Entity);

            return retorno.Entity;
        }

        public T Update(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(typeof(T).FullName);

            T exist = Entities.SingleOrDefault(t => t.Id == Entity.Id);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(Entity);
                return Entity;
            }

            return null;
        }

        public bool Delete(long Id)
        {

            T exist = Entities.SingleOrDefault(t => t.Id == Id);
            if (exist != null)
            {
                Entities.Remove(exist);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(T entityToDelete)
        {
            if (entityToDelete == null)
                throw new ArgumentNullException(typeof(T).FullName);

            T exist = Entities.SingleOrDefault(t => t.Id == entityToDelete.Id);
            if (exist != null)
            {
                Entities.Remove(exist);
                return true;
            }

            return false;
        }

        public void Salvar()
        {
            Context.SaveChanges();
        }

        public void CreateTransaction()
        {
            Context.Database.BeginTransaction();
        }
        public void Commit()
        {
            Context.Database.CommitTransaction();
        }
        public void Rollback()
        {
            Context.Database.RollbackTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                Context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
