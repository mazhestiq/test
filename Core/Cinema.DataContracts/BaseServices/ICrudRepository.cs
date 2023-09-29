using Cinema.Domains.Entities.Base;

namespace Cinema.DataContracts.BaseServices
{
    public interface ICrudRepository<TEntity> : IQueryRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(Guid entityId);
    }
}