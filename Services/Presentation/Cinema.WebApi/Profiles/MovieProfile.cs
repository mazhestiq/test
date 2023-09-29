using AutoMapper;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.Movies;

namespace Cinema.WebApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieView>();
            CreateMap<CreateMovie, Movie>();
            CreateMap<UpdateMovie, Movie>();
        }
    }
}
