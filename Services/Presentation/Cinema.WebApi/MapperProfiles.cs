using AutoMapper;
using Cinema.Service.Implementation;
using Cinema.WebApi.Profiles;

namespace Cinema.WebApi
{
    public static class MapperProfiles
    {
        public static void UseWebApiProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile<MovieProfile>();
            config.AddProfile<TheaterProfile>();
            config.AddProfile<ShowTimeProfile>();
            config.AddProfile<ReservationProfile>();

            config.UseServiceProfiles();
        }
    }
}