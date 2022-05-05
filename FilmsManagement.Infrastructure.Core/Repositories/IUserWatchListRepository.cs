using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.Infrastructure.Core.Repositories
{
    public interface IUserWatchListRepository
    {
        Task<IReadOnlyList<UserWatchListMovie>> GetUserWatchListAsync(User user, CancellationToken cancellationToken);

        Task<IReadOnlyList<IMovie>> GetUserUnwatchedMoviesAsync(User user, CancellationToken cancellationToken);

        Task AddUserWatchListMovieAsync(User user, IMovie movie, CancellationToken cancellationToken);

        Task MarkMovieWatchedAsync(User user, IMovie movie, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
