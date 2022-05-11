using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.WebApi.ViewModels.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FilmsManagement.WebApi.Controllers
{
    [Route("watchlist/{userId}")]
    public class UserWatchListManagementController : FilmsManagementApiController
    {
        private readonly IUserWatchListDomainService _userWatchListDomainService;

        public UserWatchListManagementController(IUserWatchListDomainService userWatchListDomainService)
        {
            _userWatchListDomainService = userWatchListDomainService;
        }

        /// <summary>
        /// Get user watch list movies and tv series
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of user watch list movies and tv series</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUserWatchList(
            [FromRoute] string userId
            , CancellationToken cancellationToken
        )
        {
            var models = await _userWatchListDomainService.GetUserWatchListAsync(userId, cancellationToken);
            var viewModels = models.ToViewModel();

            return Ok(viewModels);
        }

        /// <summary>
        /// Add movie or tv serie to user watch list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{movieId}")]
        public async Task<IActionResult> AddMovieToWatchList(
            [FromRoute] string userId
            , [FromRoute] string movieId
            , CancellationToken cancellationToken
        )
        {
            await _userWatchListDomainService.AddMovieToUserWatchList(userId, movieId, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Mark movie or tv serie in user watch list as watched
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{movieId}")]
        public async Task<IActionResult> MarkMovieInWatchList(
            [FromRoute] string userId
            , [FromRoute] string movieId
            , CancellationToken cancellationToken
        )
        {
            await _userWatchListDomainService.MarkMovieInWatchListAsync(userId, movieId, cancellationToken);

            return NoContent();
        }
    }
}
