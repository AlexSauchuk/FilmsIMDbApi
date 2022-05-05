using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.Infrastructure.Core.Repositories;

namespace FilmsManagement.DomainServices
{
    public class MovieSearchDomainService : IMovieSearchDomainService
    {
        private readonly IFilmsSearchRepository _searchRepository;

        public MovieSearchDomainService(IFilmsSearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public Task<IReadOnlyList<IBaseMovie>> SearchAsync(string searchQuery, CancellationToken cancellationToken)
        {
            return _searchRepository.SearchByTitleAsync(searchQuery, cancellationToken);
        }

        public Task<IReadOnlyList<IBaseMovie>> SearchFilmsAsync(string searchQuery, CancellationToken cancellationToken)
        {
            return _searchRepository.SearchFilmsByTitleAsync(searchQuery, cancellationToken);
        }

        public Task<IReadOnlyList<IBaseMovie>> SearchSeriesAsync(string searchQuery, CancellationToken cancellationToken)
        {
            return _searchRepository.SearchSeriesByTitleAsync(searchQuery, cancellationToken);
        }
    }
}
