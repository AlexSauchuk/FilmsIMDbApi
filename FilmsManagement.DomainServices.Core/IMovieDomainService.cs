using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.DomainServices.Core
{
    public interface IMovieDomainService
    {
        Task<IMovie> GetMovieById(string id, CancellationToken cancellationToken);
    }
}
