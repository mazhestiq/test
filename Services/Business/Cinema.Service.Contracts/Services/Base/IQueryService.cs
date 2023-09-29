using System.Linq.Expressions;

namespace Cinema.Service.Contracts.Services.Base
{
    public interface IQueryService<TEntity> : IService
    {
        Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null, IEnumerable<string> includes = null);
        Task<IEnumerable<TEntity>> QueryAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetAsync(Guid entityId, IEnumerable<string> includes = null);
        Task<TEntity> GetAsync(Guid modelId, params Expression<Func<TEntity, object>>[] includes);
    }
}