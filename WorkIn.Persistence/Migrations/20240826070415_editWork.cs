using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkIn.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Countries_CountryId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Regions_RegionId",
                table: "WorkInfos");

            migrationBuilder.DropIndex(
                name: "IX_WorkInfos_CountryId",
                table: "WorkInfos");

            migrationBuilder.DropIndex(
                name: "IX_WorkInfos_RegionId",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "LastPromotionDate",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "WorkInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Bonus",
                table: "WorkInfos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "WorkInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPromotionDate",
                table: "WorkInfos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "WorkInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "WorkInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkInfos_CountryId",
                table: "WorkInfos",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkInfos_RegionId",
                table: "WorkInfos",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Countries_CountryId",
                table: "WorkInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Regions_RegionId",
                table: "WorkInfos",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
