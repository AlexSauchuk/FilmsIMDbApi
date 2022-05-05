using System;
using System.Collections.Generic;

namespace FilmsManagement.Domain.Models
{
    public interface IMovie : IBaseMovie
    {
        string Country { get; set; }

        int DurationMins { get; set; }

        IEnumerable<MovieGenre> Genres { get; set; }

        short ProductionYear { get; set; }

        float Rating { get; set; }
    }
}
