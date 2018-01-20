using System;
using Mashlan.DynamicJson.Api.Configuration.Constants;
using Mashlan.DynamicJson.Api.Configuration.Section;
using Mashlan.DynamicJson.Api.Configuration.Startup.ApiVersioning;
using Mashlan.DynamicJson.Api.Configuration.Startup.Logging;
using Mashlan.DynamicJson.Api.Configuration.Startup.Swagger;
using Mashlan.DynamicJson.DependanceInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConnectionStringsConfiguration>(Configuration.GetSection(AppSettingsSections.ConnectionStrings));
            services.Configure<LogLocationsConfiguration>(Configuration.GetSection(AppSettingsSections.LogLocations));

            var serviceProvider = services.BuildServiceProvider();
            var connectionStrings = serviceProvider.GetService<IOptions<ConnectionStringsConfiguration>>();
            var connectionString = connectionStrings.Value.AssetTrackConnection;

            ApiVersioningConfiguration.ConfigureService(services);

            DatabaseConfiguration.Configure(services, connectionString, EnvironmentVariables.GetInMemoryDbValue());

            DependencyInjectorHost.Configure(services);

            SwaggerStartupConfiguration.ConfigureService(services, environment);

            services.AddMvc();
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, 
            ILoggerFactory loggerFactory, 
            IApiVersionDescriptionProvider apiVersionDescriptionProvider, 
            IServiceProvider serviceProvider)
        {
            
            CorrelationMiddleware.Configure(app);

            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SwaggerStartupConfiguration.Configure(app, apiVersionDescriptionProvider);
            }
            
            if (EnvironmentVariables.GetInMemoryDbValue()) DependencyInjectorHost.ConfigureMock(serviceProvider);

            app.UseMvc();
        }
    }
}
