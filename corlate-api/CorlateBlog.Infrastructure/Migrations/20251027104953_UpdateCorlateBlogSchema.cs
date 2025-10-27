using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorlateBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCorlateBlogSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Blogs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Blogs");
        }
    }
}
