namespace Mashlan.DynamicJson.Api.Configuration.Startup.Swagger
{
    /// <summary>
    /// Basic information for setting up Swagger UI Display
    /// </summary>
    public class SwaggerDetails
    {
        /// <summary>
        /// Title of the Api that Swagger is displaying
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the Api being displayed by Swagger
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// When swagger is setup this is the xml file configured
        /// in the Properties of the project file.
        /// </summary>
        public string ApiXmlFile { get; set; }
    }
}