using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddArticlescolums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookAuthor",
                table: "Articles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookCover",
                table: "Articles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookNumberOfPages",
                table: "Articles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Articles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MyNote",
                table: "Articles",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Quotes",
                table: "Articles",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewResume",
                table: "Articles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextSection",
                table: "Articles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAuthor",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "BookCover",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "BookNumberOfPages",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MyNote",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Quotes",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ReviewResume",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TextSection",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Articles");
        }
    }
}
