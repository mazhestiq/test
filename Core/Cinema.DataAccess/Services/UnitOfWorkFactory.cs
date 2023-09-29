using Cinema.Core.HttpContext;
using Cinema.DataContracts.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services
{
    public class UnitOfWorkFactory<TDbContext> : IUnitOfWorkFactory<TDbContext> where TDbContext : DbContext
    {
        private readonly DataContracts.Contracts.IDbContextFactory<TDbContext> _dbContextFactory;

        private readonly IRequestContextProvider _httpContextProvider;

        public UnitOfWorkFactory(DataContracts.Contracts.IDbContextFactory<TDbContext> dbContextFactory, IRequestContextProvider httpContextProvider)
        {
            _dbContextFactory = dbContextFactory;
            _httpContextProvider = httpContextProvider;
        }

        public IUnitOfWork<TDbContext> Create()
        {
            return new UnitOfWork<TDbContext>(_dbContextFactory, _httpContextProvider);
        }

        public void Rollback()
        {
            var dbContext = _dbContextFactory.GetContext();

            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }
    }
}