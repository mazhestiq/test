using System.Linq.Expressions;
using Cinema.Core.Extensions;
using Cinema.Domains.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services.Base
{
    public abstract class BaseQueryRepository<TEntity, TDbContext> : BaseRepository<TEntity, TDbContext> where TEntity : class,IEntity where TDbContext : DbContext
    {
        protected BaseQueryRepository(DataContracts.Contracts.IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }

        public virtual Task<TEntity[]> QueryAsync(Expression<Func<TEntity, bool>> filter = null, IEnumerable<string> includes = null)
        {
            var query = DbSetAsNoTracking.AddIncludes(includes);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToArrayAsync();
        }

        public virtual Task<TEntity[]> QueryAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = DbSetAsNoTracking.AddIncludes(includes);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToArrayAsync();
        }

        public virtual Task<TEntity[]> QueryAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = DbSetAsNoTracking.AddIncludes(includes);
            
            return query.ToArrayAsync();
        }

        public virtual Task<TEntity> GetAsync(Guid entityId, IEnumerable<string> includes = null)
        {
            return this.DbSetAsNoTracking.AddIncludes(includes).FirstOrDefaultAsync(n => n.Id == entityId);
        }


        public virtual Task<TEntity> GetAsync(Guid entityId, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.DbSetAsNoTracking.AddIncludes(includes).FirstOrDefaultAsync(n => n.Id == entityId);
        }

    }
}