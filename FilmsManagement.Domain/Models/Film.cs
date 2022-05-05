using System;
using System.Collections.Generic;

namespace FilmsManagement.Domain.Models
{
    public class Film : IMovie
    {
        public Guid? Id { get; set; }

        public string Country { get; set; }

        public int DurationMins { get; set; }
        
        public IEnumerable<MovieGenre> Genres { get; set; }

        public short ProductionYear { get; set; }

        public float Rating { get; set; }

        public string Title { get; set; }

        public string ExternalId { get; set; }
    }
}
