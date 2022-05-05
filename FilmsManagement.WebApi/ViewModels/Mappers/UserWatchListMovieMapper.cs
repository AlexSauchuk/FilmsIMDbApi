using System.Collections.Generic;
using System.Linq;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.WebApi.ViewModels.Mappers
{
    public static class UserWatchListMovieMapper
    {
        public static IReadOnlyList<UserWatchListMovieViewModel> ToViewModel(this IEnumerable<UserWatchListMovie> models)
        {
            return models?.Select(ToViewModel).ToList() ?? new List<UserWatchListMovieViewModel>();
        }

        public static UserWatchListMovieViewModel ToViewModel(this UserWatchListMovie domain)
        {
            return new UserWatchListMovieViewModel 
            {
                MovieViewModel = domain.Movie.ToViewModel(),
                Watched = domain.Watched
            };
        }
    }
}
