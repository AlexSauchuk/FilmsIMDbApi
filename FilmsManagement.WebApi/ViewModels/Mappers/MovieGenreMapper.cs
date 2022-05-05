using System.Collections.Generic;
using System.Linq;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.WebApi.ViewModels.Mappers
{
    public static class MovieGenreMapper
    {
        public static IReadOnlyList<MovieGenreViewModel> ToViewModel(this IEnumerable<MovieGenre> domainList)
        {
            return domainList.Select(ToViewModel).ToList();
        }

        public static MovieGenreViewModel ToViewModel(this MovieGenre domain)
        {
            return new MovieGenreViewModel
            {
                Name = domain.Name
            };
        }
    }
}
