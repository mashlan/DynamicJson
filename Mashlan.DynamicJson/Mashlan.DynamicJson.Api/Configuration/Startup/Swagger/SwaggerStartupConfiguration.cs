using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Mashlan.DynamicJson.Api.Configuration.Startup.Swagger
{
    /// <summary>
    /// Swagger Startup Configuration
    /// </summary>
    public static class SwaggerStartupConfiguration
    {
        /// <summary>
        ///     Setup configuration for Swagger
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="hostingEnvironment">Hosting Environment</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="services"/> is <see langword="null"/></exception>
        /// <exception cref="System.ArgumentNullException">Condition.</exception>
        public static void ConfigureService(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            /*if(services == null) { throw new ArgumentNullException(nameof(services));  }
            if(hostingEnvironment == null) {  throw new ArgumentNullException(nameof(hostingEnvironment)); }
            if(apiVersionDescriptionProvider == null) { throw new ArgumentNullException(nameof(apiVersionDescriptionProvider)); }
            if (details == null) { throw new ArgumentNullException(nameof(details)); }
            if (string.IsNullOrWhiteSpace(details.ApiXmlFile)) { throw new ArgumentException($"{nameof(details.ApiXmlFile)} cannot be empty."); }
*/
            var path = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "DynamicJson.Api.xml");

            services.AddSwaggerGen(options =>
            {
                // resolve the IApiVersionDescriptionProvider service
                // note: that we have to build a temporary service provider here because one has not been created yet
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                //add a swagger document for each discovered API version
                // note: you might choose to skip or document deprecated API versions differently
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }


                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();

                options.IncludeXmlComments(path);
                options.DescribeAllEnumsAsStrings();

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });
        }

        /// <summary>
        /// ConfigureService the Swagger Endpoints and Middleware
        /// </summary>
        /// <param name="application"></param>
        /// <param name="apiVersionDescriptionProvider"></param>
        /// <exception cref="System.ArgumentNullException"><paramref name="application"/> is <see langword="null"/></exception>
        public static void Configure(IApplicationBuilder application, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if(application == null) {  throw new ArgumentNullException(nameof(application)); }
            if(apiVersionDescriptionProvider == null) { throw new ArgumentNullException(nameof(apiVersionDescriptionProvider)); }
            
            // Enable middleware to serve generated Swagger as a JSON endpoint
            application.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            application.UseSwaggerUI(config =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }

        internal static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info
            {
                Title = $"Dynamic JSON API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "Test project for working with dynamic json",
                Contact = new Contact { Name = "Eric Mashlan", Email = "eric.mashlan@gmail.com" },
                TermsOfService = "WTFPL",
                License = new License { Name = "WTFPL", Url = "https://github.com/CubicleJockey/OnionPattern/blob/Develop/LICENSE.md" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}