using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.Infrastructure.Core.Repositories
{
    public interface IFilmsSearchRepository
    {
        Task<IReadOnlyList<IBaseMovie>> SearchByTitleAsync(string title, CancellationToken cancellationToken);

        Task<IReadOnlyList<IBaseMovie>> SearchFilmsByTitleAsync(string title, CancellationToken cancellationToken);

        Task<IReadOnlyList<IBaseMovie>> SearchSeriesByTitleAsync(string title, CancellationToken cancellationToken);

        Task<IMovie> GetFilmByIdAsync(string id, CancellationToken cancellationToken);

        Task<MovieWikipedia> GetFilmWikipedia(string id, CancellationToken cancellationToken);

        Task<MoviePoster> GetFilmPoster(string id, CancellationToken cancellationToken);
    }
}
