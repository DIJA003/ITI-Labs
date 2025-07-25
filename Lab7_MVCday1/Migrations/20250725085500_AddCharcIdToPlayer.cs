using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab7_MVCday1.Migrations
{
    /// <inheritdoc />
    public partial class AddCharcIdToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharcId",
                table: "players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_CharcId",
                table: "players",
                column: "CharcId");

            migrationBuilder.AddForeignKey(
                name: "FK_players_Character_CharcId",
                table: "players",
                column: "CharcId",
                principalTable: "Character",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_players_Character_CharcId",
                table: "players");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropIndex(
                name: "IX_players_CharcId",
                table: "players");

            migrationBuilder.DropColumn(
                name: "CharcId",
                table: "players");
        }
    }
}
