using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Data.Migrations
{
    public partial class ChangeTableNamePlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_Playrs_PlayerId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Playrs_Positions_PositionId",
                table: "Playrs");

            migrationBuilder.DropForeignKey(
                name: "FK_Playrs_Teams_TeamId",
                table: "Playrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playrs",
                table: "Playrs");

            migrationBuilder.RenameTable(
                name: "Playrs",
                newName: "Players");

            migrationBuilder.RenameIndex(
                name: "IX_Playrs_TeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Playrs_PositionId",
                table: "Players",
                newName: "IX_Players_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_Players_PlayerId",
                table: "PlayerStatistics",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_Players_PlayerId",
                table: "PlayerStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Playrs");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Playrs",
                newName: "IX_Playrs_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PositionId",
                table: "Playrs",
                newName: "IX_Playrs_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playrs",
                table: "Playrs",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_Playrs_PlayerId",
                table: "PlayerStatistics",
                column: "PlayerId",
                principalTable: "Playrs",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playrs_Positions_PositionId",
                table: "Playrs",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playrs_Teams_TeamId",
                table: "Playrs",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
