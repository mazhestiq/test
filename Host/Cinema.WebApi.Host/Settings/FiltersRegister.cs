using Cinema.Core.HttpFilters;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApi.Host.Settings
{
    public static class FiltersRegister
    {
        public static void AddFilters(this MvcOptions options, IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            options.Filters.Add(new ErrorHandlingFilter(provider.GetService<ILogger<ErrorHandlingFilter>>()));
            options.Filters.Add(new ValidateModelAttribute(provider.GetService<ILogger<ValidateModelAttribute>>()));
            options.Filters.Add(new OkResultHandlingFilter());
            options.Filters.Add(new BadRequestResultHandlingFilter());
            options.Filters.Add(new NotFoundResultHandlingFilter());
        }
    }
}