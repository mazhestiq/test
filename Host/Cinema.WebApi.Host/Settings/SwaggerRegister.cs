using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Cinema.WebApi.Host.Settings
{
    public static class SwaggerConfigure
    {
        private const string ApplicationName = "Cinema.WebApi";

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(t => t.FullName);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApplicationName, Version = "v1" });
                
                var filePaths = new[]
                {
                    Path.Combine(System.AppContext.BaseDirectory, $"Cinema.WebApi.xml"),
                    Path.Combine(System.AppContext.BaseDirectory, $"Cinema.WebApi.Host.xml"),
                    Path.Combine(System.AppContext.BaseDirectory, $"Cinema.Domains.xml")
                };
                foreach (var filePath in filePaths)
                {
                    if (File.Exists(filePath))
                    {
                        c.IncludeXmlComments(filePath);
                    }
                }

                c.UseInlineDefinitionsForEnums();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.DescribeAllParametersInCamelCase();
            });
        }

        public static void InitSwagger(this IApplicationBuilder builder)
        {
            builder.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    //Clear servers -element in swagger.json because it got the wrong port when hosted behind reverse proxy
                    swagger.Servers.Clear();
                });
            });

            builder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.DisplayRequestDuration();
                options.EnableDeepLinking();
                options.ShowExtensions();
                options.EnableValidator();
                options.DocExpansion(DocExpansion.None);
            });
        }
    }
}
