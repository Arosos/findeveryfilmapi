using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using findeveryfilmapi.TvMaze.Dtos;

namespace findeveryfilmapi.TvMaze
{
    public interface ITvMazeClient
    {
        Task<List<SearchPeopleResult>> SearchPeopleAsync(string query, CancellationToken cancellationToken);
    }
}
