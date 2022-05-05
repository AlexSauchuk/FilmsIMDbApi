using System.Collections.Generic;
using System.Linq;
using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Http.DataModels;

namespace FilmsManagement.Infrastructure.Http.Mappers
{
    public static class MovieGenreMapper
    {
        public static IEnumerable<MovieGenre> ToDomainModel(this IEnumerable<MovieGenreDataModel> models)
        {
            return models?.Select(ToDomainModel);
        }

        public static MovieGenre ToDomainModel(this MovieGenreDataModel model)
        {
            return new MovieGenre
            {
                Name = model.Name
            };
        }
    }
}
