using System;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;

namespace FilmsManagement.Infrastructure.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

        Task<User> GetUserByMailAsync(string mail, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
