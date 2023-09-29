using Cinema.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.WebApi
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseWebApiServices(this IServiceCollection service)
        {
            service.UseServices();

            return service;
        }
    }
}
