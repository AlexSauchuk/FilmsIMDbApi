using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Http.DataModels;
using System.Linq;

namespace FilmsManagement.Infrastructure.Http.Mappers
{
    public static class MoviePosterMapper
    {
        public static MoviePoster ToDomainModel(this MoviePosterDataModel model)
        {
            var posterDataModel = model.Posters.FirstOrDefault();

            return new MoviePoster
            {
                Id = posterDataModel?.Id,
                Link = posterDataModel?.Link,
                MovieId = model.MovieId,
                MovieTitle = model.MovieTitle
            };
        }
    }
}
