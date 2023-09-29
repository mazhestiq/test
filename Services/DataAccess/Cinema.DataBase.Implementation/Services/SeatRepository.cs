using Cinema.DataAccess;
using Cinema.DataAccess.Services.Base;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;

namespace Cinema.DataBase.Implementation.Services;

public class SeatRepository : BaseCrudRepository<Seat, CinemaDbContext>, ISeatRepository
{
    public SeatRepository(IDbContextFactory<CinemaDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
}