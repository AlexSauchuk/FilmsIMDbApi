using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsManagement.Infrastructure.Sql.FilmsManagement.Infrastructure.Sql
{
    public partial class FixColumnsLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FilmsManagement",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1a7785dd-4d8b-4d77-afb2-dd8d870b782e"));

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                schema: "FilmsManagement",
                table: "User",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "FilmsManagement",
                table: "Movie",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "FilmsManagement",
                table: "Movie",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "FilmsManagement",
                table: "User",
                columns: new[] { "Id", "Mail", "Nickname" },
                values: new object[] { new Guid("cdfda73e-9b95-4f04-a6c3-ba7c8ba843a8"), "alexandr.sauchuk@gmail.com", "Alex0319742" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FilmsManagement",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cdfda73e-9b95-4f04-a6c3-ba7c8ba843a8"));

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                schema: "FilmsManagement",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "FilmsManagement",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "FilmsManagement",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "FilmsManagement",
                table: "User",
                columns: new[] { "Id", "Mail", "Nickname" },
                values: new object[] { new Guid("1a7785dd-4d8b-4d77-afb2-dd8d870b782e"), "alexandr.sauchuk@gmail.com", "Alex0319742" });
        }
    }
}
