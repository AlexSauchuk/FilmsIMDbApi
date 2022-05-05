using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Http.DataModels;

namespace FilmsManagement.Infrastructure.Http.Mappers
{
    public static class FilmMapper
    {
        public static Film ToDomainModel(this FilmDataModel model)
        {
            return new Film
            {
                ExternalId = model.Id,
                Country = model.Country,
                DurationMins = model.DurationMins,
                Genres = model.Genres.ToDomainModel(),
                ProductionYear = model.ProductionYear,
                Rating = model.Rating,
                Title = model.Title
            };
        }
    }
}
