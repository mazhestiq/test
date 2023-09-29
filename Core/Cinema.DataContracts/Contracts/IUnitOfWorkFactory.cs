using Microsoft.EntityFrameworkCore;

namespace Cinema.DataContracts.Contracts
{
    public interface IUnitOfWorkFactory<TDbContext> where TDbContext : DbContext
    {
        IUnitOfWork<TDbContext> Create();
        void Rollback();
    }
}