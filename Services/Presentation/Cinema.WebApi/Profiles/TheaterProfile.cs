using AutoMapper;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.Theaters;

namespace Cinema.WebApi.Profiles;

public class TheaterProfile : Profile
{
    public TheaterProfile()
    {
        CreateMap<Theater, TheaterView>();
        CreateMap<CreateTheater, Theater>();
        CreateMap<UpdateTheater, Theater>();

        CreateMap<SeatModel, Seat>().ReverseMap();
    }
}