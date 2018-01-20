using Mashlan.DynamicJson.Domain.Services;
using Mashlan.DynamicJson.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Mashlan.DynamicJson.DependanceInjection
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection service)
        {
            service.AddTransient<IQueueService, QueueService>();
            service.AddTransient<IContextService, ContextService>();
        }
    }
}