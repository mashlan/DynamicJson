using Mashlan.DynamicJson.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mashlan.DynamicJson.DependanceInjection
{
    public static class DatabaseConfiguration
    {
        public static void Configure(IServiceCollection service, string connectionString, bool isInMemory = false)
        {
            service.AddDbContext<AssetTrackContext>(options =>
            {
                if (isInMemory) { options.UseInMemoryDatabase("Mashlan.DynamicJson"); }
                else { options.UseSqlServer(connectionString); }
            });

            service.AddScoped<DbContext>(provider =>
            {
                var test = "";
                return provider.GetService<AssetTrackContext>();
            });
        }
    }
}