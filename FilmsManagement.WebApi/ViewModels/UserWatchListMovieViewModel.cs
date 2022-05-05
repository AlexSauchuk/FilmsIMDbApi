using Newtonsoft.Json;

namespace FilmsManagement.WebApi.ViewModels
{
    public class UserWatchListMovieViewModel
    {
        [JsonProperty("Movie")]
        public IBaseMovieViewModel MovieViewModel { get; set; }

        public bool Watched { get; set; }
    }
}
