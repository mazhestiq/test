using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace AspNetCoreGAEWebApi
{
    public static class WebApiAutoMapper
    {
        public static void UseAspNetCoreGAEWebApi(IMapperConfigurationExpression config)
        {
            AspNetCoreGAEWebApiMapping(config);
        }

        private static void AspNetCoreGAEWebApiMapping(IMapperConfigurationExpression config)
        {
            config.AddProfiles(typeof(WebApiAutoMapper).Assembly);
        }
    }
}
