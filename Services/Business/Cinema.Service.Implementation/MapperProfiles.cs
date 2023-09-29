using AutoMapper;

namespace Cinema.Service.Implementation
{
    public static class MapperProfiles
    {
        public static void UseServiceProfiles(this IMapperConfigurationExpression config)
        {
            //config.AddProfile<ContactsProfile>();
        }
    }
}