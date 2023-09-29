using Cinema.DataContracts.BaseServices;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities.Base;
using Cinema.Service.Contracts.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Service.Implementation.Services.Base
{
    public abstract class BaseCrudService<TEntity, TRepository, TDbContext> : BaseQueryService<TEntity, TRepository>, ICrudService<TEntity> where TDbContext : DbContext
        where TEntity : class, IEntity
        where TRepository : ICrudRepository<TEntity>
    {
        public IUnitOfWorkFactory<TDbContext> UnitOfWorkFactory { get; }

        protected BaseCrudService(IUnitOfWorkFactory<TDbContext> unitOfWorkFactory, TRepository repository)
            : base(repository)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            using var uow = UnitOfWorkFactory.Create();
            await Repository.CreateAsync(entity);
            await uow.CommitAsync();

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using var uow = UnitOfWorkFactory.Create();
            await Repository.UpdateAsync(entity);
            await uow.CommitAsync();

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                uow.Rollback();

                await Repository.DeleteAsync(id);

                await uow.CommitAsync();
            }

            return await Task.Run(() => true);
        }

    }
}