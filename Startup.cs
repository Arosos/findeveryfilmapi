using findeveryfilmapi.Configuration;
using findeveryfilmapi.TvMaze;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TMDbLib.Client;

namespace findeveryfilmapi
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
#if DEBUG
            services.AddSingleton<IEnvironment, DebugEnvironment>();
#else
            services.AddSingleton<IEnvironment, Environment>();
#endif
            services.AddSingleton<TheMovieDbApiConfiguration>();
            services.AddScoped(serviceProvider => new TMDbClient(serviceProvider.GetService<TheMovieDbApiConfiguration>().ApiKey));

            services.AddHttpClient<ITvMazeClient, TvMazeClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
