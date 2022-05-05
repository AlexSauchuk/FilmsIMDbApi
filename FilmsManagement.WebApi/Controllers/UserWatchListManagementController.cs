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

        [HttpPut]
        [Route("{movieId}")]
        public async Task<IActionResult> DeleteMovieFromWatchList(
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
