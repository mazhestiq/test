using Cinema.DataAccess;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services.Base;

namespace Cinema.Service.Implementation.Services;

public class MovieService : BaseCrudService<Movie, IMovieRepository, CinemaDbContext>, IMovieService
{
    public MovieService(IUnitOfWorkFactory<CinemaDbContext> unitOfWorkFactory, IMovieRepository repository) : base(unitOfWorkFactory, repository)
    {
    }
}