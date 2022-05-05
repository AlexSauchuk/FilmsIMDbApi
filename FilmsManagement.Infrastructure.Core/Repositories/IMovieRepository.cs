using System;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.Infrastructure.Core.Repositories
{
    public interface IMovieRepository
    {
        Task<IMovie> GetMovieByIdAsync(string id, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
