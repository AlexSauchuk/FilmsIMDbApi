using System.Collections.Generic;

namespace FilmsManagement.WebApi.ViewModels
{
    public class MovieViewModel : IBaseMovieViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public int? DurationMins { get; set; }

        public IEnumerable<MovieGenreViewModel> Genres { get; set; }

        public short? ProductionYear { get; set; }

        public float? Rating { get; set; }

        public int? SeasonsCount { get; set; }

        public int? SeriesCount { get; set; }
    }
}
