using System;
using System.Collections.Generic;
using System.Linq;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.WebApi.ViewModels.Mappers
{
    public static class MovieMapper
    {
        public static IReadOnlyList<IBaseMovieViewModel> ToViewModel(this IReadOnlyList<IBaseMovie> domainList)
        {
            List<IBaseMovieViewModel> viewModels = domainList.Select(ToViewModel).ToList();

            return viewModels;
        }

        public static IBaseMovieViewModel ToViewModel(this IBaseMovie domain)
        {
            var viewModel = DefaultToViewModel(domain);

            switch (domain)
            {
                case MovieTitle _:
                    return viewModel;
                case TvSeries tvSeriesModel:
                    MapTvSeries(tvSeriesModel, viewModel);
                    break;
                case Film filmModel:
                    MapFilm(filmModel, viewModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(domain));
            }

            return viewModel;
        }

        private static MovieViewModel DefaultToViewModel(IBaseMovie domain)
        {
            return new MovieViewModel
            {
                Id = domain.ExternalId,
                Title = domain.Title
            };
        }

        private static void MapFilm(Film domain, MovieViewModel viewModel)
        {
            viewModel.Country = domain.Country;
            viewModel.DurationMins = domain.DurationMins;
            viewModel.Genres = domain.Genres.ToViewModel();
            viewModel.ProductionYear = domain.ProductionYear;
            viewModel.Rating = domain.Rating;
        }

        private static void MapTvSeries(TvSeries domain, MovieViewModel viewModel)
        {
            viewModel.Country = domain.Country;
            viewModel.DurationMins = domain.DurationMins;
            viewModel.Genres = domain.Genres.ToViewModel();
            viewModel.ProductionYear = domain.ProductionYear;
            viewModel.Rating = domain.Rating;
            viewModel.SeasonsCount = domain.SeasonsCount;
            viewModel.SeriesCount = domain.SeriesCount;
        }
    }
}
