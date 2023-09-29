using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Cinema.Core.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cinema.WebApi.Host.Settings
{
    public static class InfrastructureRegister
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = SetMapping();
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(configuration);
            services.AddSingleton(mapperConfig);
            services.AddSingleton(mapper);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var serviceProvider = services.BuildServiceProvider();
            var reservationSettings = serviceProvider.GetRequiredService<IOptions<ReservationSettings>>();
            services.AddSingleton(reservationSettings.Value);
        }

        private static MapperConfiguration SetMapping()
        {
            return new MapperConfiguration(UseMapping);
        }

        private static void UseMapping(IMapperConfigurationExpression config)
        {
            config.AllowNullCollections = true;

            config.AddExpressionMapping();

            config.UseWebApiProfiles();
        }
    }
}
