using System;

namespace FilmsManagement.Domain.Models
{
    public class MovieTitle : IBaseMovie
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string ExternalId { get; set; }
    }
}
