namespace findeveryfilmapi.Configuration
{
    /// <summary>
    /// For now application needs only 1 environment variable - TheMovieDbApiKey. So insert this one here.
    /// </summary>
    internal class DebugEnvironment : IEnvironment
    {
        public string GetEnvironmentVariable(string name) => "";
    }
}
