using System;
using System.Collections.Generic;

namespace FilmsManagement.Infrastructure.Sql.DataModels
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string Mail { get; set; }

        public virtual List<UserWatchListMovieModel> WatchList { get; set; }
    }
}
