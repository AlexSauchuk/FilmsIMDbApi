using System;
using System.Collections.Generic;

namespace FilmsManagement.Infrastructure.Sql.DataModels
{
    public class FilmModel : IBaseMovieModel
    {
        public Guid Id { get; set; }

        public string Country { get; set; }

        public int DurationMins { get; set; }

        public short ProductionYear { get; set; }

        public float Rating { get; set; }

        public string Title { get; set; }

        public string ExternalId { get; set; }

        public string AdditionalState { get; set; }

        public virtual ICollection<MovieGenreModel> Genres { get; set; }
        public virtual List<UserWatchListMovieModel> UsersWatchList { get; set; }
    }
}
