using Cinema.DataAccess;
using Cinema.DataAccess.Services.Base;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;

namespace Cinema.DataBase.Implementation.Services;

public class ShowTimeRepository : BaseCrudRepository<ShowTime, CinemaDbContext>, IShowTimeRepository
{
    public ShowTimeRepository(IDbContextFactory<CinemaDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
}