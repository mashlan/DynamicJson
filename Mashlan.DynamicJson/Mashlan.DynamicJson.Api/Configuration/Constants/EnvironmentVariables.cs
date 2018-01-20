using System;

namespace Mashlan.DynamicJson.Api.Configuration.Constants
{
    /// <summary>
    /// Constant collection of Environment variables we will be using.
    /// </summary>
    public static class EnvironmentVariables
    {
        public static string ASPNETCORE_ENVIRONMENT = nameof(ASPNETCORE_ENVIRONMENT);
        public static string InMemoryDb => nameof(InMemoryDb);

        public static bool GetInMemoryDbValue()
        {
            var inMemoryDbEnvironmentVar = Environment.GetEnvironmentVariable(InMemoryDb);
            var inMemoryDb = string.Equals(bool.TrueString, inMemoryDbEnvironmentVar, StringComparison.CurrentCultureIgnoreCase);
            return inMemoryDb;
        }
    }
}
