using System;
using Newtonsoft.Json;

namespace findeveryfilmapi.TvMaze.Dtos
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public CountryDto Country { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Deathday { get; set; }
        public string Gender { get; set; }
        public ImageDto Image { get; set; }
        [JsonProperty("_links")]
        public LinksDto Links { get; set; }
    }
}
