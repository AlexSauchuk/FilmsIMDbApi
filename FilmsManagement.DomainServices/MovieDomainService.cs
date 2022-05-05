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
        private readonly IMovieRepository _movieRepository;
        private readonly IFilmsSearchRepository _filmsSearchRepository;

        public MovieDomainService(IMovieRepository movieRepository, IFilmsSearchRepository filmsSearchRepository)
        {
            _movieRepository = movieRepository;
            _filmsSearchRepository = filmsSearchRepository;
        }

        public async Task<IMovie> GetMovieById(string id, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id, cancellationToken) ??
                throw new MovieNotFoundException(id);

            return movie;
        }

        public async Task<IMovie> FindMovieById(string id, CancellationToken cancellationToken)
        {
            var movie = await _filmsSearchRepository.GetFilmByIdAsync(id, cancellationToken) ??
                throw new MovieNotFoundException(id);

            return movie;
        }
    }
}
