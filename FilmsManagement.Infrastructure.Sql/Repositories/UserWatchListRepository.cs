using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FilmsManagement.Domain.Models;
using FilmsManagement.Infrastructure.Core.Repositories;
using FilmsManagement.Infrastructure.MSSql;
using FilmsManagement.Infrastructure.Sql.Contexts;
using FilmsManagement.Infrastructure.Sql.DataModels;
using FilmsManagement.Infrastructure.Sql.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FilmsManagement.Infrastructure.Sql.Repositories
{
    public class UserWatchListRepository : BaseSqlRepository<FilmsManagementContext>, IUserWatchListRepository
    {
        public UserWatchListRepository(FilmsManagementContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<UserWatchListMovie>> GetUserWatchListAsync(User user, CancellationToken cancellationToken)
        {
            var userModel = await Context.Users.FirstOrDefaultAsync(model => model.Id.Equals(user.Id), cancellationToken);

            IReadOnlyList<UserWatchListMovie> domainModels = userModel?.WatchList?.ToDomainModel();

            return domainModels;
        }

        public async Task<IReadOnlyList<IMovie>> GetUserUnwatchedMoviesAsync(User user, CancellationToken cancellationToken)
        {
            var userModel = await Context.Users.FirstOrDefaultAsync(model => model.Id.Equals(user.Id), cancellationToken);

            IReadOnlyList<IMovie> domainModels = userModel?.WatchList?
                .Where(x => !x.Watched)
                .Select(x => x.Film)
                .ToDomainModel();

            return domainModels;
        }

        public async Task AddUserWatchListMovieAsync(User user, IMovie movie, CancellationToken cancellationToken)
        {
            if (!movie.Id.HasValue)
            {
                var foundMovie = await Context.Films.FirstOrDefaultAsync(x => x.ExternalId.Equals(movie.ExternalId), cancellationToken);
                if (foundMovie == null)
                {
                    var trackingEntity = await Context.AddAsync(movie.ToSqlModel(), cancellationToken);
                    foundMovie = trackingEntity.Entity;
                }

                movie.Id = foundMovie.Id;
            }

            UserWatchListMovieModel sqlModel = new UserWatchListMovieModel
            { 
                FilmId = movie.Id.Value,
                UserId = user.Id,
                Watched = false
            };

            var userModel = await Context.Users.FirstOrDefaultAsync(model => model.Id.Equals(user.Id), cancellationToken);

            userModel.WatchList ??= new List<UserWatchListMovieModel>();
            if (!userModel.WatchList.Any(x => x.FilmId.Equals(sqlModel.FilmId) && x.UserId.Equals(sqlModel.UserId)))
            {
                userModel.WatchList.Add(sqlModel);
            }
        }

        public async Task MarkMovieWatchedAsync(User user, IMovie movie, CancellationToken cancellationToken)
        {
            var userModel = await Context.Users.FirstOrDefaultAsync(model => model.Id.Equals(user.Id), cancellationToken);
            var watchListMovieModel = userModel.WatchList?.FirstOrDefault(model => model.Film.ExternalId.Equals(movie.ExternalId));

            if (watchListMovieModel != null)
            {
                watchListMovieModel.Watched = true;
            }
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
