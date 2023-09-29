using Cinema.Domains.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.Base
{
    public abstract class BaseRepository<TEntity, TDbContext> where TEntity : class,IEntity where TDbContext : DbContext
    {
        protected DataContracts.Contracts.IDbContextFactory<TDbContext> DbContextFactory;

        protected TDbContext Context => DbContextFactory.GetContext();

        protected BaseRepository(DataContracts.Contracts.IDbContextFactory<TDbContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        protected virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        protected virtual DbSet<T> GetDbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

        protected virtual IQueryable<TEntity> DbSetAsNoTracking => Context.Set<TEntity>().AsNoTracking();
    }
}
