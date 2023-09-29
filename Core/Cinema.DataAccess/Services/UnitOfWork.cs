using Cinema.Core.Extensions;
using Cinema.Core.HttpContext;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Services
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private readonly DbContext _dbContextManager;

        public UnitOfWork(DataContracts.Contracts.IDbContextFactory<TDbContext> dbContextFactory, IRequestContextProvider httpRequestProvider)
        {
            _dbContextManager = dbContextFactory.GetContext();

            _dbContextManager.ChangeTracker.Tracked += (obj, arg) =>
            {
                var state = arg.Entry.State;
                var entity = arg.Entry.Entity;

                arg.Entry.ExcludeDbGeneratedForUpdate();

                if (state != EntityState.Added) 
                    return;

                if (entity is BaseEntity baseEntity && baseEntity.Id == Guid.Empty)
                {
                    baseEntity.Id = Guid.NewGuid();
                }

                var currentDateTime = DateTime.Now;

                if (entity is AuditCreationEntity auditCreationEntity)
                {
                    auditCreationEntity.CreatedAt = currentDateTime;
                    auditCreationEntity.CreatedBy = "";
                }

                if (!(entity is AuditEntity auditEntity)) 
                    return;

                auditEntity.ModifiedAt = currentDateTime;
                auditEntity.ModifiedBy = "";
            };

            _dbContextManager.ChangeTracker.StateChanged += (obj, arg) =>
            {
                var state = arg.Entry.State;
                var entity = arg.Entry.Entity;

                arg.Entry.ExcludeDbGeneratedForUpdate();

                if (state != EntityState.Modified || !(entity is AuditEntity auditEntity)) 
                    return;

                auditEntity.ModifiedAt = DateTime.Now;
                auditEntity.ModifiedBy = "";
            };
        }

        public int Commit()
        {
            return _dbContextManager.ChangeTracker.HasChanges() ? _dbContextManager.SaveChanges() : 0;
        }

        public async Task<int> CommitAsync()
        {
            if (_dbContextManager.ChangeTracker.HasChanges())
            {
                return await _dbContextManager.SaveChangesAsync();
            }

            return 0;
        }

        public void Rollback()
        {
            foreach (var dbEntityEntry in _dbContextManager.ChangeTracker.Entries().ToArray())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }

        ~UnitOfWork()
        {
            Dispose();
        }

        public void Dispose()
        {

        }
    }
}