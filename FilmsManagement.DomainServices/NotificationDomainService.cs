using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.Domain.Requests;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.Infrastructure.Core;

namespace FilmsManagement.DomainServices
{
    public class NotificationDomainService : INotificationDomainService
    {
        private readonly IMailService _mailService;
        private readonly IMovieSearchDomainService _movieSearchDomainService;
        private readonly IUserDomainService _userDomainService;
        private readonly IUserWatchListDomainService _userWatchListDomainService;

        public NotificationDomainService(
            IMailService mailService
            , IMovieSearchDomainService movieSearchDomainService
            , IUserDomainService userDomainService
            , IUserWatchListDomainService userWatchListDomainService
        )
        {
            _mailService = mailService;
            _movieSearchDomainService = movieSearchDomainService;
            _userDomainService = userDomainService;
            _userWatchListDomainService = userWatchListDomainService;
        }

        public async Task SendUserNotificationAsync(string userMail, CancellationToken cancellationToken)
        {
            var user = await _userDomainService.GetUserByMailAsync(userMail, cancellationToken);

            var response = await _userWatchListDomainService.CheckNotificationForUser(user, cancellationToken);
        
            if (response.NotifyUser)
            {
                var movieWiki = await _movieSearchDomainService.SearchMovieWikipediaAsync(response.SuggestedMovie.ExternalId, cancellationToken);
                var moviePoster = await _movieSearchDomainService.SearchMoviePosterAsync(response.SuggestedMovie.ExternalId, cancellationToken);

                var mailRequest = new MailRequest
                {
                    Body = GetEmailBody(response.SuggestedMovie, movieWiki, moviePoster),
                    Subject = "You have a lot of unwatched movies!",
                    ToEmail = userMail
                };

                await _mailService.SendEmailAsync(mailRequest, cancellationToken);
            }
        }

        private string GetEmailBody(IMovie movie, MovieWikipedia movieWikipedia, MoviePoster moviePoster)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"<h3>{movie.Title}</h3><h4>Rating: </h4>{movie.Rating}");
            stringBuilder.Append(movieWikipedia.PlotShortHtml);
            stringBuilder.Append($"<br/><img src='{moviePoster.Link}'>");

            return stringBuilder.ToString();
        }
    }
}
