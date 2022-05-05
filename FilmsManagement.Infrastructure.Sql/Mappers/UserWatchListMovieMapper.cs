using System.Collections.Generic;
using System.Linq;
using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Sql.DataModels;

namespace FilmsManagement.Infrastructure.Sql.Mappers
{
    public static class UserWatchListMovieMapper
    {
        public static IReadOnlyList<UserWatchListMovie> ToDomainModel(this IEnumerable<UserWatchListMovieModel> models)
        {
            return models?.Select(ToDomainModel)?.ToList();
        }

        public static UserWatchListMovie ToDomainModel(this UserWatchListMovieModel model)
        {
            return new UserWatchListMovie
            {
                Movie = model.Film.ToDomainModel(),
                Watched = model.Watched
            };
        }

        public static UserWatchListMovieModel ToSqlModel(this UserWatchListMovie domain)
        {
            return new UserWatchListMovieModel
            {
                Film = domain.Movie.ToSqlModel(),
                Watched = domain.Watched
            };
        }
    }
}
