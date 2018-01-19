namespace Mashlan.DynamicJson.Api.Configuration.Section
{
    /// <summary>
    /// Represents the Logging section in the appsettings.json files
    /// </summary>
    public class LoggingConfiguration
    {
        /// <summary>
        /// Wheater or not to include the scopes
        /// </summary>
        public bool IncludeScopes { get; set; }

        /// <summary>
        /// Log Level Configuration from None to Verbse.
        /// </summary>
        public LogLevelConfiguration LogLevelConfiguration { get; set; }
    }
}
