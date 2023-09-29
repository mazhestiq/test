using Cinema.DataContracts.BaseServices;
using Cinema.Domains.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.Base
{
    public abstract class BaseCrudRepository<TEntity, TDbContext> : BaseQueryRepository<TEntity, TDbContext>, ICrudRepository<TEntity> where TEntity : class, IEntity where TDbContext : DbContext
    {
        protected BaseCrudRepository(DataContracts.Contracts.IDbContextFactory<TDbContext> dbContextFactory)
            : base(dbContextFactory)
        {

        }

        
        public virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            entity = DbSet.Add(entity).Entity;

            return Task.FromResult(entity);
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            var data = DbSet.Find(entity.Id);

            DbContextFactory.GetContext().Entry(data).CurrentValues.SetValues(entity);

            return Task.FromResult(entity);
        }

        public virtual async Task<bool> DeleteAsync(Guid entityId)
        {
            var dbEntity = await this.GetAsync(entityId).ConfigureAwait(false);
            
            DbSet.Remove(dbEntity);

            return true;
        }

    }
}