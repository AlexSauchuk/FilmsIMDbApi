using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Http.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmsManagement.Infrastructure.Http.Mappers
{
    public static class MovieTitleMapper
    {
        public static IEnumerable<MovieTitle> ToDomainModel(this IEnumerable<MovieTitleDataModel> models)
        {
            return models?.Select(ToDomainModel);
        }

        public static MovieTitle ToDomainModel(this MovieTitleDataModel model)
        {
            return new MovieTitle
            {
                ExternalId = model.Id,
                Title = model.Title
            };
        }
    }
}
