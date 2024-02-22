using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddArticlesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookGenre",
                table: "Articles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookYear",
                table: "Articles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Articles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReviewTitle",
                table: "Articles",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookGenre",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "BookYear",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ReviewTitle",
                table: "Articles");
        }
    }
}
