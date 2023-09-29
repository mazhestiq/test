using System.Reflection;
using Cinema.Core.ModelBinders;
using Cinema.WebApi.Host.Settings;
using Newtonsoft.Json;

namespace Cinema.WebApi.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            Configuration = AppConfiguration.Configure();
            WebHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureOptions(Configuration);

            services.AddInfrastructure(Configuration);
            services.ConfigureDbContext();
            services.UseWebApiServices();

            services
                .AddMvcCore(t => {
                    t.AddFilters(services);
                    t.AllowEmptyInputInBodyModelBinding = true;
                })
                .AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                        options.SerializerSettings.Converters.Add(new CustomEnumConverter());
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    })
                .AddApiExplorer()
                .AddApplicationPart(typeof(ContainerExtensions).GetTypeInfo().Assembly);


             services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            ;

                    });
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();
            services.AddHealthChecks();
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider svp)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health-check");
            
            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.InitSwagger();

        }

        static class SetterHttpContextAccessor
        {
            static IHttpContextAccessor _httpContextAccessor;

            public static IHttpContextAccessor Get()
            {
                return _httpContextAccessor;
            }

            public static void Set(IHttpContextAccessor contextAccessor)
            {
                _httpContextAccessor = contextAccessor;
            }

        }
    }
}
