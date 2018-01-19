using Mashlan.DynamicJson.Api.Configuration.Constants;
using Mashlan.DynamicJson.Api.Configuration.Program;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Mashlan.DynamicJson.Api
{
    public class Program
    {
        private static ILoggingBuilder logger;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.UseStartup<Startup>()
                .UseSerilog()
                .ConfigureLogging((context, loggingBuilder) =>
                {
                    logger = loggingBuilder;
                    loggingBuilder
                        .AddConfiguration(context.Configuration.GetSection(AppSettingsSections.Logging))
                        .AddConsole()
                        .AddDebug()
                        .AddSerilog();

                    ConfigureSerilog.Configure(context.HostingEnvironment, context.Configuration, loggingBuilder, "Mashlan_DynamicJson");
                });

            return builder.Build();
        }
    }
}
