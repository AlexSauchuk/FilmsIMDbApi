using System;

namespace FilmsManagement.Infrastructure.Sql.DataModels
{
    public class UserWatchListMovieModel
    {
        public bool Watched { get; set; }

        public Guid UserId { get; set; }
        public virtual UserModel User { get; set; }

        public Guid FilmId { get; set; }
        public virtual FilmModel Film { get; set; }
    }
}
