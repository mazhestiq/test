using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreGAEWebApi;
using AutoMapper;

namespace AspNetCoreGAE.Settings
{
    public static class AutoMapperRegister
    {
        public static MapperConfiguration SetMapping()
        {
            Mapper.Initialize(UseAspNetCoreGAE);

            return new MapperConfiguration(UseAspNetCoreGAE);
        }

        private static void UseAspNetCoreGAE(IMapperConfigurationExpression config)
        {
            WebApiAutoMapper.UseAspNetCoreGAEWebApi(config);
        }
    }
}
