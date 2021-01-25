using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace findeveryfilmapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly TMDbClient _apiClient;

        public FilmsController(TMDbClient apiClient)
        {
            _apiClient = apiClient;
        }

        // GET api/films?query=Harry&page=1
        [HttpGet]
        public async Task<ActionResult<SearchContainer<SearchMovie>>> Get(string query, CancellationToken cancellationToken, int page = 1)
        {
            return await _apiClient.SearchMovieAsync(query, page: page, cancellationToken: cancellationToken);
        }
    }
}
