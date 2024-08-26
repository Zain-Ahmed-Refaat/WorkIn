using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkIn.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Countries_CountryId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Profiles",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_CountryId",
                table: "Profiles",
                newName: "IX_Profiles_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Cities_CityId",
                table: "Profiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Cities_CityId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Profiles",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_CityId",
                table: "Profiles",
                newName: "IX_Profiles_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Countries_CountryId",
                table: "Profiles",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
