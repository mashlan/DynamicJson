namespace Mashlan.DynamicJson.Api.Configuration.Constants
{
    /// <summary>
    /// These are constants that map to the environments  for the Project.
    /// Mock will be a mode more than an environment.
    /// </summary>
    public static class EnvironmentTypes
    {
        public static string Dev = nameof(Dev).ToLower();
        public static string Local = nameof(Local).ToLower();
        public static string Prod = nameof(Prod).ToLower();
        public static string Qat = nameof(Qat).ToLower();
        public static string Uat = nameof(Uat).ToLower();
    }
}