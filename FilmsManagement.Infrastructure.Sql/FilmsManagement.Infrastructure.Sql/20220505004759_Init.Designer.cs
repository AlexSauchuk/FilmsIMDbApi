﻿// <auto-generated />
using System;
using FilmsManagement.Infrastructure.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmsManagement.Infrastructure.Sql.FilmsManagement.Infrastructure.Sql
{
    [DbContext(typeof(FilmsManagementContext))]
    [Migration("20220505004759_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("FilmsManagement")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmModelMovieGenreModel", b =>
                {
                    b.Property<Guid>("FilmsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("FilmModelMovieGenreModel");
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.FilmModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("ProductionYear")
                        .HasColumnType("smallint");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique()
                        .HasFilter("[ExternalId] IS NOT NULL");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.MovieGenreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a7785dd-4d8b-4d77-afb2-dd8d870b782e"),
                            Mail = "alexandr.sauchuk@gmail.com",
                            Nickname = "Alex0319742"
                        });
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.UserWatchListMovieModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Watched")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("UserWatchListMovieModel");
                });

            modelBuilder.Entity("FilmModelMovieGenreModel", b =>
                {
                    b.HasOne("FilmsManagement.Infrastructure.Sql.DataModels.FilmModel", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsManagement.Infrastructure.Sql.DataModels.MovieGenreModel", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.UserWatchListMovieModel", b =>
                {
                    b.HasOne("FilmsManagement.Infrastructure.Sql.DataModels.FilmModel", "Film")
                        .WithMany("UsersWatchList")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsManagement.Infrastructure.Sql.DataModels.UserModel", "User")
                        .WithMany("WatchList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.FilmModel", b =>
                {
                    b.Navigation("UsersWatchList");
                });

            modelBuilder.Entity("FilmsManagement.Infrastructure.Sql.DataModels.UserModel", b =>
                {
                    b.Navigation("WatchList");
                });
#pragma warning restore 612, 618
        }
    }
}