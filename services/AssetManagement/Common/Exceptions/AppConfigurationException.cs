namespace AssetManager.Common.Exceptions
{
    public class AppConfigurationException : Exception
    {
        public AppConfigurationException() : base("Application not configured correctly") { }
    }
}