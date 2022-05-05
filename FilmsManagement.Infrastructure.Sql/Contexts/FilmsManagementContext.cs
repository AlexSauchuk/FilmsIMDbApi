using System;
using FilmsManagement.Infrastructure.Core.Configurations;
using FilmsManagement.Infrastructure.MSSql;
using FilmsManagement.Infrastructure.Sql.Configurations;
using FilmsManagement.Infrastructure.Sql.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FilmsManagement.Infrastructure.Sql.Contexts
{
    public class FilmsManagementContext : BaseSqlContext
    {
        public FilmsManagementContext(ISqlConnectionStringProvider sqlConnectionStringProvider) : base(sqlConnectionStringProvider)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FilmsManagement");
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new WatchListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<UserModel>().HasData(new UserModel 
            {
                Id = Guid.NewGuid(),
                Mail = "alexandrsavchuk.97@gmail.com",
                Nickname = "Alex0319742"
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FilmModel> Films { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<MovieGenreModel> MovieGenres { get; set; }
    }
}
