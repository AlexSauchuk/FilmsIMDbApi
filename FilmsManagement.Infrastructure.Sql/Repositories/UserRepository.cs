using System;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Core.Repositories;
using FilmsManagement.Infrastructure.MSSql;
using FilmsManagement.Infrastructure.Sql.Contexts;
using FilmsManagement.Infrastructure.Sql.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FilmsManagement.Infrastructure.Sql.Repositories
{
    public class UserRepository : BaseSqlRepository<FilmsManagementContext>, IUserRepository
    {
        public UserRepository(FilmsManagementContext context) : base(context)
        {
        }

        public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var model = await Context.Users.FirstOrDefaultAsync(user => user.Id.Equals(userId), cancellationToken);

            return model?.ToDomainModel() ?? null;
        }

        public async Task<User> GetUserByMailAsync(string mail, CancellationToken cancellationToken)
        {
            var model = await Context.Users.FirstOrDefaultAsync(user => user.Mail.Equals(mail), cancellationToken);

            return model?.ToDomainModel() ?? null;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
