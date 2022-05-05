using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Sql.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmsManagement.Infrastructure.Sql.Mappers
{
    public static class MovieGenreMapper
    {
        public static IEnumerable<MovieGenre> ToDomainModel(this IEnumerable<MovieGenreModel> models)
        {
            return models?.Select(ToDomainModel).ToList();
        }

        public static MovieGenre ToDomainModel(this MovieGenreModel model)
        {
            return new MovieGenre
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static ICollection<MovieGenreModel> ToSqlModel(this IEnumerable<MovieGenre> domainModels)
        {
            return domainModels?.Select(ToSqlModel).ToList();
        }

        public static MovieGenreModel ToSqlModel(this MovieGenre domain)
        {
            return new MovieGenreModel
            {
                Id = domain.Id,
                Name = domain.Name
            };
        }
    }
}
