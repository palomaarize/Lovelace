using Lovelace.Core.Entities.Base.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lovelace.Data.Context
{
    public class Contexto : DbContext
    {
        public DbSet<User> Users { get; set; }
    
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

    }
}