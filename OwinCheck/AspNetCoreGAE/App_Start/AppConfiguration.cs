using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreGAE.App_Start
{
    public static class AppConfiguration
    {
        public static IConfigurationRoot Configure()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            return configuration;
        }

        public static IServiceCollection UseAspNetCoreGaeInfrastructure(this IServiceCollection services, MapperConfiguration mapperConfiguration)
        {
            services.AddSingleton(mapperConfiguration);
            services.AddTransient(resolver => mapperConfiguration.CreateMapper(resolver.GetService));

            return services;
        }
    }
}
