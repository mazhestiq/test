using Cinema.DataAccess;
using Cinema.DataAccess.Services.Base;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;

namespace Cinema.DataBase.Implementation.Services
{
    public class ContactRepository : BaseCrudRepository<Contact, CinemaDbContext>, IContactRepository
    {
        public ContactRepository(IDbContextFactory<CinemaDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}