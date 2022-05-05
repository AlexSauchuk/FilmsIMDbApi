using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsManagement.Infrastructure.Sql.FilmsManagement.Infrastructure.Sql
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FilmsManagement");

            migrationBuilder.CreateTable(
                name: "Movie",
                schema: "FilmsManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ProductionYear = table.Column<short>(type: "smallint", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdditionalState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                schema: "FilmsManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "FilmsManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmModelMovieGenreModel",
                schema: "FilmsManagement",
                columns: table => new
                {
                    FilmsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmModelMovieGenreModel", x => new { x.FilmsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_FilmModelMovieGenreModel_Movie_FilmsId",
                        column: x => x.FilmsId,
                        principalSchema: "FilmsManagement",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmModelMovieGenreModel_MovieGenre_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "FilmsManagement",
                        principalTable: "MovieGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWatchListMovieModel",
                schema: "FilmsManagement",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Watched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchListMovieModel", x => new { x.UserId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_UserWatchListMovieModel_Movie_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "FilmsManagement",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWatchListMovieModel_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "FilmsManagement",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "FilmsManagement",
                table: "User",
                columns: new[] { "Id", "Mail", "Nickname" },
                values: new object[] { new Guid("1a7785dd-4d8b-4d77-afb2-dd8d870b782e"), "alexandr.sauchuk@gmail.com", "Alex0319742" });

            migrationBuilder.CreateIndex(
                name: "IX_FilmModelMovieGenreModel_GenresId",
                schema: "FilmsManagement",
                table: "FilmModelMovieGenreModel",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ExternalId",
                schema: "FilmsManagement",
                table: "Movie",
                column: "ExternalId",
                unique: true,
                filter: "[ExternalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchListMovieModel_FilmId",
                schema: "FilmsManagement",
                table: "UserWatchListMovieModel",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmModelMovieGenreModel",
                schema: "FilmsManagement");

            migrationBuilder.DropTable(
                name: "UserWatchListMovieModel",
                schema: "FilmsManagement");

            migrationBuilder.DropTable(
                name: "MovieGenre",
                schema: "FilmsManagement");

            migrationBuilder.DropTable(
                name: "Movie",
                schema: "FilmsManagement");

            migrationBuilder.DropTable(
                name: "User",
                schema: "FilmsManagement");
        }
    }
}
