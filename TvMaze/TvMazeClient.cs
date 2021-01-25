using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using findeveryfilmapi.TvMaze.Dtos;
using Newtonsoft.Json;

namespace findeveryfilmapi.TvMaze
{
    internal class TvMazeClient : ITvMazeClient
    {
        private const string ApiUri = "http://api.tvmaze.com/";

        private readonly HttpClient _httpClient;

        public TvMazeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ApiUri);
        }

        public async Task<List<SearchPeopleResult>> SearchPeopleAsync(string query, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetStringAsync($"search/people?q={query}");
            var result = JsonConvert.DeserializeObject<List<SearchPeopleResult>>(response);
            return result;
        }
    }
}
