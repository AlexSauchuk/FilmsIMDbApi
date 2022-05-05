using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Http.DataModels;

namespace FilmsManagement.Infrastructure.Http.Mappers
{
    public static class MovieWikipediaMapper
    {
        public static MovieWikipedia ToDomainModel(this MovieWikipediaDataModel model)
        {
            return new MovieWikipedia
            {
                MovieId = model.FilmId,
                Title = model.Title,
                PlotShortHtml = model.PlotShort.Html,
                WikiUrl = model.Url
            };
        }
    }
}
