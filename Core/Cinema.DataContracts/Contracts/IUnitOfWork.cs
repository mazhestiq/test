using Microsoft.EntityFrameworkCore;

namespace Cinema.DataContracts.Contracts
{
    public interface IUnitOfWork<TDbContext> : IDisposable where TDbContext : DbContext
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}