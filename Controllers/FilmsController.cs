using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace findeveryfilmapi.Controllers
{
    [Route("api")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly TMDbClient _apiClient;

        public FilmsController(TMDbClient apiClient)
        {
            _apiClient = apiClient;
        }

        // GET api/films?query=Harry&page=1
        [HttpGet("films")]
        public async Task<ActionResult<SearchContainer<SearchMovie>>> Get(string query, CancellationToken cancellationToken, int page = 1)
        {
            return await _apiClient.SearchMovieAsync(query, page: page, cancellationToken: cancellationToken);
        }

        // GET api/filmDetails?query=671
        [HttpGet("filmDetails")]
        public async Task<ActionResult<Movie>> FilmDetails(int query, CancellationToken cancellationToken)
        {
            return await _apiClient.GetMovieAsync(query, cancellationToken: cancellationToken);
        }

        // GET api/filmActors?query=671
        [HttpGet("filmActors")]
        public async Task<ActionResult<Credits>> FilmActors(int query, CancellationToken cancellationToken)
        {
            var movie = await _apiClient.GetMovieAsync(query, MovieMethods.Credits, cancellationToken: cancellationToken);
            return movie.Credits;
        }
    }
}
