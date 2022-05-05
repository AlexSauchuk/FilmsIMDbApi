using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.DomainServices.Core;
using FilmsManagement.Infrastructure.Core.Exceptions;
using FilmsManagement.Infrastructure.Core.Repositories;

namespace FilmsManagement.DomainServices
{
    public class MovieDomainService : IMovieDomainService
    {
        private readonly IFilmsSearchRepository _filmsSearchRepository;

        public MovieDomainService(IFilmsSearchRepository filmsSearchRepository)
        {
            _filmsSearchRepository = filmsSearchRepository;
        }

        public async Task<IMovie> GetMovieById(string id, CancellationToken cancellationToken)
        {
            var movie = await _filmsSearchRepository.GetFilmByIdAsync(id, cancellationToken) ??
                throw new MovieNotFoundException(id);

            return movie;
        }
    }
}
