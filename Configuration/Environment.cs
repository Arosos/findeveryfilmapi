namespace findeveryfilmapi.Configuration
{
    internal class Environment : IEnvironment
    {
        public string GetEnvironmentVariable(string name) => System.Environment.GetEnvironmentVariable(name);
    }
}
