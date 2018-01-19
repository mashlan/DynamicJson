using Mashlan.DynamicJson.Api.Configuration.Startup.ApiVersioning;
using Mashlan.DynamicJson.Api.Configuration.Startup.Logging;
using Mashlan.DynamicJson.Api.Configuration.Startup.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mashlan.DynamicJson.Api
{
    /// <summary>
    ///  Application Startup Configuration
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment environment;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="env">Hosting Environment</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            environment = env;
        }

        /// <summary>
        /// Configuration information
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ApiVersioningConfiguration.ConfigureService(services);

            //ConfigureApiVersioning(services);

            services.AddMvc();

            SwaggerStartupConfiguration.ConfigureService(services, environment);
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="apiVersionDescriptionProvider"></param>
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, 
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            
            CorrelationMiddleware.Configure(app);

            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SwaggerStartupConfiguration.Configure(app, apiVersionDescriptionProvider);
            }
            
            app.UseMvc();
        }

        
        private static void ConfigureApiVersioning(IServiceCollection services)
        {
            // Add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // Note: the specified format code will format the version as "'v'major[.minor][-status]"
            // Note: Requires package: Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");

            // Add framework services.
            services.AddApiVersioning(apiVersioningOptions => { apiVersioningOptions.ReportApiVersions = true; });
        }
    }
}
