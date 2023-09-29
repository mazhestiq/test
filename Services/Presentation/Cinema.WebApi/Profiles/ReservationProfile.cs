using AutoMapper;
using Cinema.Domains.Entities;
using Cinema.Domains.Models.Reservations;

namespace Cinema.WebApi.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<CreateReservation, Reservation>();
        CreateMap<CreateContact, Contact>();

        CreateMap<Reservation, ReservationView>();

        CreateMap<ShowTime, ShowTimeView>();
        CreateMap<Seat, SeatView>();
        CreateMap<Contact, ContactView>();
    }
}