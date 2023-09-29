using Cinema.DataBase.Contracts.Services;
using Cinema.DataBase.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.DataBase.Implementation
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseDatabase(this IServiceCollection service)
        {
            service.AddScoped<IContactRepository, ContactRepository>();
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            service.AddScoped<IReservationRepository, ReservationRepository>();
            service.AddScoped<ISeatRepository, SeatRepository>();
            service.AddScoped<ITheaterRepository, TheaterRepository>();


            return service;
        }
    }
}
