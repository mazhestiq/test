using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreGAEWebApi
{
    public static class ContainerExtentions
    {
        public static IServiceCollection UseAspNetCoreGAEWebApi(this IServiceCollection service)
        {

            return service;
        }
    }
}
