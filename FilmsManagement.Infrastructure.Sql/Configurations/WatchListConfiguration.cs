using FilmsManagement.Infrastructure.Sql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsManagement.Infrastructure.Sql.Configurations
{
    public class WatchListConfiguration : IEntityTypeConfiguration<UserWatchListMovieModel>
    {
        public void Configure(EntityTypeBuilder<UserWatchListMovieModel> builder)
        {
            builder.HasKey(_ => new { _.UserId, _.FilmId });

            builder.HasOne(watchList => watchList.Film)
                .WithMany(film => film.UsersWatchList)
                .HasForeignKey(watchList => watchList.FilmId);

            builder.HasOne(watchList => watchList.User)
                .WithMany(user => user.WatchList)
                .HasForeignKey(watchList => watchList.UserId);
        }
    }
}
