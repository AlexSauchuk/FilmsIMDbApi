using System.Collections.Generic;
using System.Linq;
using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Sql.DataModels;

namespace FilmsManagement.Infrastructure.Sql.Mappers
{
    public static class MovieMapper
    {
        public static IReadOnlyList<IMovie> ToDomainModel(this IEnumerable<FilmModel> models)
        {
            return models?.Select(ToDomainModel).ToList();
        }

        public static IMovie ToDomainModel(this FilmModel model)
        {
            return new Film
            {
                Id = model.Id,
                ExternalId = model.ExternalId,
                Country = model.Country,
                DurationMins = model.DurationMins,
                Genres = model.Genres.ToDomainModel(),
                ProductionYear = model.ProductionYear,
                Rating = model.Rating,
                Title = model.Title
            };
        }

        public static FilmModel ToSqlModel(this IMovie domain)
        {
            var viewModel = new FilmModel
            {
                ExternalId = domain.ExternalId,
                Country = domain.Country,
                DurationMins = domain.DurationMins,
                Genres = domain.Genres.ToSqlModel(),
                ProductionYear = domain.ProductionYear,
                Rating = domain.Rating,          
                Title = domain.Title
            };

            return viewModel;
        }
    }
}
