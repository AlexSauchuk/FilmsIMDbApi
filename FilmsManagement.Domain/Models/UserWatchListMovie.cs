using System.Collections.Generic;

namespace FilmsManagement.Domain.Models
{
    public class UserWatchListMovie
    {
        public IMovie Movie { get; set; }

        public bool Watched { get; set; }
    }
}
