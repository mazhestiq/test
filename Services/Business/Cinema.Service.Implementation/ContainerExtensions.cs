using Cinema.DataBase.Implementation;
using Cinema.Service.Contracts.Services;
using Cinema.Service.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Service.Implementation
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseServices(this IServiceCollection service)
        {
            service.AddScoped<IDataTableFilterService, DataTableFilterService>();

            service.AddScoped<IContactService, ContactService>();
            service.AddScoped<ITheaterService, TheaterService>();
            service.AddScoped<ISeatService, SeatService>();
            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<IShowTimeService, ShowTimeService>();
            service.AddScoped<IReservationService, ReservationService>();

            service.UseDatabase();

            return service;
        }
    }
}
