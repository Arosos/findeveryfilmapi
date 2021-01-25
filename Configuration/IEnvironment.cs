namespace findeveryfilmapi.Configuration
{
    internal interface IEnvironment
    {
        string GetEnvironmentVariable(string name);
    }
}
