using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsManagement.Infrastructure.Sql.FilmsManagement.Infrastructure.Sql
{
    public partial class FixFilmColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FilmsManagement",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cdfda73e-9b95-4f04-a6c3-ba7c8ba843a8"));

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "FilmsManagement",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "DurationMins",
                schema: "FilmsManagement",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "FilmsManagement",
                table: "User",
                columns: new[] { "Id", "Mail", "Nickname" },
                values: new object[] { new Guid("b39b41a0-e16b-466f-8aba-bdd6935d330f"), "alexandr.sauchuk@gmail.com", "Alex0319742" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FilmsManagement",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b39b41a0-e16b-466f-8aba-bdd6935d330f"));

            migrationBuilder.DropColumn(
                name: "DurationMins",
                schema: "FilmsManagement",
                table: "Movie");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                schema: "FilmsManagement",
                table: "Movie",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                schema: "FilmsManagement",
                table: "User",
                columns: new[] { "Id", "Mail", "Nickname" },
                values: new object[] { new Guid("cdfda73e-9b95-4f04-a6c3-ba7c8ba843a8"), "alexandr.sauchuk@gmail.com", "Alex0319742" });
        }
    }
}
