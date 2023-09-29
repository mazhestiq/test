using Cinema.Core.HttpContext;
using Cinema.DataAccess.Services;
using Cinema.DataContracts.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.DataAccess
{
    public static class ContainerExtensions
    {
        public static IServiceCollection UseUowServices(this IServiceCollection service)
        {
            service.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            service.AddScoped(typeof(IUnitOfWorkFactory<>), typeof(UnitOfWorkFactory<>));
            service.AddScoped(typeof(IDbContextFactory<>), typeof(DbContextFactory<>));

            service.AddScoped<IRequestContext, HttpRequestContext>();
            service.AddScoped<IRequestContextProvider, HttpRequestContextProvider>();

            return service;
        }
    }
}
