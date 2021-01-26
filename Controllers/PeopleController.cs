using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using findeveryfilmapi.TvMaze;
using findeveryfilmapi.TvMaze.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace findeveryfilmapi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ITvMazeClient _tvMazeClient;

        public PeopleController(ITvMazeClient tvMazeClient)
        {
            _tvMazeClient = tvMazeClient;
        }

        // GET api/searchPeople?query=lauren
        [HttpGet("searchPeople")]
        public async Task<ActionResult<IEnumerable<SearchPeopleResult>>> SearchPeople(string query, CancellationToken cancellationToken)
        {
            return await _tvMazeClient.SearchPeopleAsync(query, cancellationToken);
        }
    }
}
