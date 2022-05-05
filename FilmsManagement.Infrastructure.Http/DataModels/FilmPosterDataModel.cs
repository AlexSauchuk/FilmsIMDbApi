using System.Collections.Generic;
using Newtonsoft.Json;

namespace FilmsManagement.Infrastructure.Http.DataModels
{
    public class MoviePosterDataModel
    {
        [JsonProperty("imDbId")]
        public string MovieId { get; set; }

        public string MovieTitle { get; set; }

        public IEnumerable<PosterItem> Posters { get; set; }
    }

    public class PosterItem
    {
        public string Id { get; set; }

        public string Link { get; set; }
    }
}
