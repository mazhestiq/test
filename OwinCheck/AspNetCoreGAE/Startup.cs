using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCoreGAE.App_Start;
using AspNetCoreGAE.Settings;
using AspNetCoreGAEWebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreGAE
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var mapper = AutoMapperRegister.SetMapping();

            services.UseAspNetCoreGaeInfrastructure(mapper);

            services.AddMvcCore()
                .AddJsonFormatters()
                .AddApiExplorer()
                .AddApplicationPart(typeof(ContainerExtentions).GetTypeInfo().Assembly);

            services.UseAspNetCoreGAEWebApi();

            services.AddSwagger();
        }

        public IConfigurationRoot Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.InitSwagger();

            app.UseMvc();
        }
    }
}
