using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.DomainServices.Core
{
    public interface IMovieSearchDomainService
    {
        Task<IReadOnlyList<IBaseMovie>> SearchAsync(string searchQuery, CancellationToken cancellationToken);

        Task<IReadOnlyList<IBaseMovie>> SearchFilmsAsync(string searchQuery, CancellationToken cancellationToken);

        Task<IReadOnlyList<IBaseMovie>> SearchSeriesAsync(string searchQuery, CancellationToken cancellationToken);
    }
}
