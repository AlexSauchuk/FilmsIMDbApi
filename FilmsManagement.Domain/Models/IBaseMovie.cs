using System;

namespace FilmsManagement.Domain.Models
{
    public interface IBaseMovie
    {
        Guid? Id { get; set; }

        string Title { get; set; }

        string ExternalId { get; set; }
    }
}
