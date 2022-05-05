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
    public class MovieRepository : BaseSqlRepository<FilmsManagementContext>, IMovieRepository
    {
        public MovieRepository(FilmsManagementContext context) : base(context)
        {
        }

        public async Task<IMovie> GetMovieByIdAsync(string id, CancellationToken cancellationToken)
        {
            var model = await Context.Films.FirstOrDefaultAsync(film => film.ExternalId.Equals(id), cancellationToken);

            return model?.ToDomainModel() ?? null;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
