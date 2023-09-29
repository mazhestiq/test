using Cinema.DataAccess;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services.Base;

namespace Cinema.Service.Implementation.Services;

public class TheaterService : BaseCrudService<Theater, ITheaterRepository, CinemaDbContext>, ITheaterService
{
    public TheaterService(IUnitOfWorkFactory<CinemaDbContext> unitOfWorkFactory, ITheaterRepository repository) : base(unitOfWorkFactory, repository)
    {
    }
}