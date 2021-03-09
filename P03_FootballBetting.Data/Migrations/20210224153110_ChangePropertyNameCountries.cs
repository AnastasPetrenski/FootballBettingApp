using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Data.Migrations
{
    public partial class ChangePropertyNameCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Contries_CountryId",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contries",
                table: "Contries");

            migrationBuilder.RenameTable(
                name: "Contries",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Contries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contries",
                table: "Contries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Contries_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Contries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
