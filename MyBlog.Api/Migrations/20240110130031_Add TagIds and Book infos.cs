using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTagIdsandBookinfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Articles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(List<int?>),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AddColumn<List<int?>>(
                name: "TagIds",
                table: "Articles",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagIds",
                table: "Articles");

            migrationBuilder.AlterColumn<List<int?>>(
                name: "TagId",
                table: "Articles",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
