using System.Linq.Expressions;

namespace Cinema.DataContracts.BaseServices
{
    public interface IQueryRepository<TEntity>
    {
        Task<TEntity[]> QueryAsync(Expression<Func<TEntity, bool>> filter = null, IEnumerable<string> includes = null);
        Task<TEntity[]> QueryAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity[]> QueryAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetAsync(Guid modelId, IEnumerable<string> includes = null);
        Task<TEntity> GetAsync(Guid entityId, params Expression<Func<TEntity, object>>[] includes);

    }
}
