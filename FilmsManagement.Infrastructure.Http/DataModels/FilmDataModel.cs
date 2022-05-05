using System.Collections.Generic;
using Newtonsoft.Json;

namespace FilmsManagement.Infrastructure.Http.DataModels
{
    public class FilmDataModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        [JsonProperty("Countries")]
        public string Country { get; set; }

        [JsonProperty("runtimeMins")]
        public int DurationMins { get; set; }

        [JsonProperty("genresList")]
        public IEnumerable<MovieGenreDataModel> Genres { get; set; }

        [JsonProperty("year")]
        public short ProductionYear { get; set; }

        [JsonProperty("imDBRating")]
        public float Rating { get; set; }
    }
}
