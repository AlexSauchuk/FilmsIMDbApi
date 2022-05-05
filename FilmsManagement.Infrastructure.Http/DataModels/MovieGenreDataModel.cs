using Newtonsoft.Json;

namespace FilmsManagement.Infrastructure.Http.DataModels
{
    public class MovieGenreDataModel
    {
        [JsonProperty("key")]
        public string Name { get; set; }
    }
}
