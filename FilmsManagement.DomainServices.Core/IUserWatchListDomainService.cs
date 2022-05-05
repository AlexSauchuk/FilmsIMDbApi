using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.DomainServices.Core
{
    public interface IUserWatchListDomainService
    {
        Task<IReadOnlyList<UserWatchListMovie>> GetUserWatchListAsync(string userId, CancellationToken cancellationToken);

        Task AddMovieToUserWatchList(string userId, string movieId, CancellationToken cancellationToken);

        Task MarkMovieInWatchListAsync(string userId, string movieId, CancellationToken cancellationToken);
    }
}
