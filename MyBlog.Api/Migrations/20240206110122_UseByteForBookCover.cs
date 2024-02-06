using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class UseByteForBookCover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Articles\" DROP COLUMN \"BookCover\"");

            migrationBuilder.AddColumn<byte[]>(
                name: "BookCover",
                table: "Articles",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookCover",
                table: "Articles",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");
        }
    }
}
