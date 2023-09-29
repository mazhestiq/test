using Cinema.DataAccess;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services.Base;

namespace Cinema.Service.Implementation.Services;

public class SeatService : BaseCrudService<Seat, ISeatRepository, CinemaDbContext>, ISeatService
{
    public SeatService(IUnitOfWorkFactory<CinemaDbContext> unitOfWorkFactory, ISeatRepository repository) : base(unitOfWorkFactory, repository)
    {
    }
}