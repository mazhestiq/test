using Cinema.Core.Configs;
using Cinema.DataAccess;
using Cinema.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cinema.WebApi.Host.Settings
{
    public static class DbContextRegister
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbConnection = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>();

            services.AddDbContext<CinemaDbContext>(options =>
            {
                options.UseInMemoryDatabase(dbConnection.Value.CinemaApiDb);
            });

            var db = services.BuildServiceProvider().GetService<CinemaDbContext>();
            db.AddMovies();
            db.AddTheaters();
            db.AddShowTimes();

            services.UseUowServices();

            return services;
        }
    }
}
