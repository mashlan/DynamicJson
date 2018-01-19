namespace Mashlan.DynamicJson.Api.Configuration.Section
{
    /// <summary>
    /// Represents the LogLocations section in the appsettings.json file
    /// </summary>
    public class LogLocationsConfiguration
    {
        /// <summary>
        /// File Location for logs when running locally.
        /// </summary>
        public string Local { get; set; }

        /// <summary>
        /// File location for logs in Docker where Splunk will gather information from.
        /// </summary>
        public string Docker { get; set; }
    }
}