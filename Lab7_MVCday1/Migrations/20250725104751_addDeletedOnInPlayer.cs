using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab7_MVCday1.Migrations
{
    /// <inheritdoc />
    public partial class addDeletedOnInPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "players",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "players");
        }
    }
}
