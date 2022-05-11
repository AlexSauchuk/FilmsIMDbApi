using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.WebApi.ViewModels.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FilmsManagement.WebApi.Controllers
{
    [Route("search")]
    public class SearchController : FilmsManagementApiController
    {
        private readonly IMovieSearchDomainService _movieSearchDomainService;

        public SearchController(IMovieSearchDomainService movieSearchDomainService)
        {
            _movieSearchDomainService = movieSearchDomainService;
        }

        /// <summary>
        /// Search a movie and tv series by title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>List of movies and tv series with passed title</returns>
        [HttpGet]
        [Route("{title}")]
        public async Task<IActionResult> SearchByTitle([FromRoute] string title, CancellationToken cancellationToken)
        {
            var foundMovies = await _movieSearchDomainService.SearchAsync(title, cancellationToken);
            var viewModel = foundMovies.ToViewModel();

            return Ok(viewModel);
        }

        /// <summary>
        /// Search a film by title.
        /// </summary>
        /// <param name="filmTitle"></param>
        /// <returns>List of movies with passed title</returns>
        [HttpGet]
        [Route("films/{filmTitle}")]
        public async Task<IActionResult> GetFilmsByTitle([FromRoute] string filmTitle, CancellationToken cancellationToken)
        {
            var foundFilms = await _movieSearchDomainService.SearchFilmsAsync(filmTitle, cancellationToken);
            var viewModel = foundFilms.ToViewModel();

            return Ok(viewModel);
        }

        /// <summary>
        /// Search a tv series by title.
        /// </summary>
        /// <param name="seriesTitle"></param>
        /// <returns>List of tv series with passed title</returns>
        [HttpGet]
        [Route("series/{seriesTitle}")]
        public async Task<IActionResult> GetSeriesByTitle([FromRoute] string seriesTitle, CancellationToken cancellationToken)
        {
            var foundSeries = await _movieSearchDomainService.SearchSeriesAsync(seriesTitle, cancellationToken);
            var viewModel = foundSeries.ToViewModel();

            return Ok(viewModel);
        }
    }
}
