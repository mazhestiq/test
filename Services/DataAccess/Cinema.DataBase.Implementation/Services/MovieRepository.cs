using Cinema.DataAccess;
using Cinema.DataAccess.Services.Base;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;

namespace Cinema.DataBase.Implementation.Services;

public class MovieRepository : BaseCrudRepository<Movie, CinemaDbContext>, IMovieRepository
{
    public MovieRepository(IDbContextFactory<CinemaDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
}