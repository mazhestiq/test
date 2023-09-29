using Microsoft.EntityFrameworkCore;

namespace Cinema.DataContracts.Contracts
{
    public interface IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        TDbContext GetContext();
    }
}
