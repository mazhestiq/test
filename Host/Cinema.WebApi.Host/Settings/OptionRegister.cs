using Cinema.Core.Configs;

namespace Cinema.WebApi.Host.Settings
{
    public static class OptionRegister
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterConfiguration<ConnectionStrings>(configuration)
                .RegisterConfiguration<ApplicationInfo>(configuration)
                .RegisterConfiguration<ReservationSettings>(configuration);
        }

        private static IServiceCollection RegisterConfiguration<T>(this IServiceCollection services,
            IConfiguration configuration) where T:class,new()
        {
            return services.Configure<T>(configuration.GetSection<T>());
        }

        private static IConfigurationSection GetSection<T>(this IConfiguration configuration)
        {
            return configuration.GetSection(GetSectionName<T>());
        }

        private static string GetSectionName<T>()
        {
            return typeof(T).Name;
        }
    }
}
