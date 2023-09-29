using Cinema.DataAccess;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services.Base;

namespace Cinema.Service.Implementation.Services
{
    public class ContactService : BaseCrudService<Contact, IContactRepository, CinemaDbContext>, IContactService
    {
        public ContactService(IUnitOfWorkFactory<CinemaDbContext> unitOfWorkFactory, IContactRepository repository) : base(unitOfWorkFactory, repository)
        {
        }
    }
}