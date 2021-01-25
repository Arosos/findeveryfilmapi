namespace findeveryfilmapi.Configuration
{
    internal class TheMovieDbApiConfiguration
    {
        private const string ApiKeyVariable = "the_movie_db_api_key";

        private readonly IEnvironment environment;

        public TheMovieDbApiConfiguration(IEnvironment environment)
        {
            this.environment = environment;
        }

        public string ApiKey => environment.GetEnvironmentVariable(ApiKeyVariable);
    }
}
