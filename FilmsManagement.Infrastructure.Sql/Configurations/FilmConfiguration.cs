using FilmsManagement.Infrastructure.Sql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsManagement.Infrastructure.Sql.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<FilmModel>
    {
        public void Configure(EntityTypeBuilder<FilmModel> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Country)
                .HasMaxLength(500);

            builder.Property(_ => _.DurationMins)
                .IsRequired();

            builder.Property(_ => _.ProductionYear);

            builder.Property(_ => _.Rating)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(_ => _.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(_ => _.ExternalId)
                .IsUnique();
            builder.Property(_ => _.ExternalId);

            builder.Property(_ => _.AdditionalState);
        }
    }
}
