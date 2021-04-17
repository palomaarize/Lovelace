using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Lovelace.Core.Entities.Base.Entity;

namespace Lovelace.Core.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(long Id, params Expression<Func<T, object>>[] includes);

        T Get(Expression<Func<T, bool>> filters, string thenIncludes = "", params Expression<Func<T, object>>[] includes);

        IQueryable<T> AddDefaultIncludes(IQueryable<T> query);

        List<T> GetAll(Expression<Func<T, bool>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filters = null,
            params Expression<Func<T, object>>[] includes);

        T Add(T Entity);

        T Update(T Entity);

        bool Delete(long Id);

        bool Delete(T entityToDelete);

        void Salvar();
        void CreateTransaction();
        void Commit();
        void Rollback();

    }
}
