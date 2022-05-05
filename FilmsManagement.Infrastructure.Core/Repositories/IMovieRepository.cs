using FilmsManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsManagement.Infrastructure.Core.Repositories
{
    public interface IMovieRepository
    {
        Task<IBaseMovie> GetMovieByIdAsync(Guid userId, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
