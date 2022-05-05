using FilmsManagement.Infrastructure.Sql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsManagement.Infrastructure.Sql.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenreModel>
    {
        public void Configure(EntityTypeBuilder<MovieGenreModel> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.Name)
                .IsRequired();
        }
    }
}
