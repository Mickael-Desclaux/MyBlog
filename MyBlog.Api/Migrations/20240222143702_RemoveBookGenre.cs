using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBookGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookGenre",
                table: "Articles");

            migrationBuilder.AlterColumn<List<string>>(
                name: "BookGenres",
                table: "Articles",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "BookGenres",
                table: "Articles",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookGenre",
                table: "Articles",
                type: "text",
                nullable: true);
        }
    }
}
