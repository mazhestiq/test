using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services
{
    public class DbContextFactory<TContext> : DataContracts.Contracts.IDbContextFactory<TContext> where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public DbContextFactory(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TContext GetContext()
        {
            return _dbContext;
        }
    }
}
