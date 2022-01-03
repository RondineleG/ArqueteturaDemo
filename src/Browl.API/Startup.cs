using Browl.API.Configuration;
using Browl.API.Extensions;
using Browl.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Browl.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                  );

            services.AddAutoMapper(typeof(Startup));

            services.AddApiConfig();

            services.AddSwaggerConfig();

            services.AddMemoryCache();

            services.AddCustomSwagger();

            DependencyResolver.Resolve(services);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiConfig(env);

            app.UseSwaggerConfig();

        }

    }
}
