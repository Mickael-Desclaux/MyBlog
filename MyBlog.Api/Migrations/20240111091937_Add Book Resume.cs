using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBookResume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookResume",
                table: "Articles",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookResume",
                table: "Articles");
        }
    }
}
