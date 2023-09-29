using AutoMapper;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.ShowTimes;

namespace Cinema.WebApi.Profiles;

public class ShowTimeProfile : Profile
{
    public ShowTimeProfile()
    {
        CreateMap<ShowTime, ShowTimeView>();

        CreateMap<CreateShowTime, ShowTime>()
            .ForMember(src => src.Seats, dest => dest.MapFrom(t => t.SeatIds.Select(x=> new ShowTimeSeat { SeatId =  x}).ToArray()));

        CreateMap<ShowTimeSeat, SeatView>()
            .ForMember(src => src.Id, dest => dest.MapFrom(t => t.Seat.Id))
            .ForMember(src => src.Place, dest => dest.MapFrom(t => t.Seat.Place))
            .ForMember(src => src.Row, dest => dest.MapFrom(t => t.Seat.Row));
    }
}