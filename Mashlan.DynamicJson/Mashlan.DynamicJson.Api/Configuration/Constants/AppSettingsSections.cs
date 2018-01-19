namespace Mashlan.DynamicJson.Api.Configuration.Constants
{
    /// <summary>
    /// AppSetting section constants
    /// 
    /// These are to be used in the Configuration.SetSection(...) method.
    /// </summary>
    public class AppSettingsSections
    {
        /// <summary>
        /// Connection String Configuration Sections
        /// </summary>
        public static string ConnectionStrings = nameof(ConnectionStrings);

        /// <summary>
        /// Logging Configuration Sections
        /// </summary>
        public static string Logging = nameof(Logging);

        /// <summary>
        /// Log Locations Depending on build environment
        /// </summary>
        public static string LogLocations = nameof(LogLocations);
    }
}
