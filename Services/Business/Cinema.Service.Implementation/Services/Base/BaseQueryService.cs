using System.Linq.Expressions;
using Cinema.DataContracts.BaseServices;
using Cinema.Domains.Entities.Base;
using Cinema.Service.Contracts.Services.Base;

namespace Cinema.Service.Implementation.Services.Base
{
    public abstract class BaseQueryService<TEntity, TRepository> : BaseService, IQueryService<TEntity>
        where TEntity : class, IEntity
        where TRepository : ICrudRepository<TEntity>
    {
        protected TRepository Repository { get; }

        protected BaseQueryService(TRepository repository)
        {
            Repository = repository;
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null,
            IEnumerable<string> includes = null)
        {
            return await Repository.QueryAsync(filter, includes);
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Repository.QueryAsync(filter, includes);
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await Repository.QueryAsync(includes);
        }

        public async Task<TEntity> GetAsync(Guid modelId, IEnumerable<string> includes = null)
        {
            return await Repository.GetAsync(modelId, includes);
        }


        public virtual async Task<TEntity> GetAsync(Guid modelId, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Repository.GetAsync(modelId, includes);
        }
    }
}