using System;

namespace FilmsManagement.Infrastructure.Sql.DataModels
{
    public interface IBaseMovieModel
    {
        public Guid Id { get; set; }
    }
}
