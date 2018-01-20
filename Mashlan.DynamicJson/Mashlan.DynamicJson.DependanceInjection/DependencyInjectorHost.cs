using System;
using Mashlan.DynamicJson.DataAccess;
using Mashlan.DynamicJson.MockData;
using Microsoft.Extensions.DependencyInjection;

namespace Mashlan.DynamicJson.DependanceInjection
{
    public static class DependencyInjectorHost
    {
        public static void Configure(IServiceCollection services)
        {
            RepositoriesConfiguration.Configure(services);
        }

        public static void ConfigureMock(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AssetTrackContext>();
            var injector = new MockDataInjector(context);
            injector.InjectAllAsync();
        }
    }
}
