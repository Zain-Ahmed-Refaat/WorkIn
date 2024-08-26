using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkIn.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Cities_CityId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Countries_CountryId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Departments_DepartmentId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_JobTitles_JobTitleId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Profiles_EmployeeId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Profiles_ManagerId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Regions_RegionId",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "WorkInfos");

            migrationBuilder.DropColumn(
                name: "WorkEmail",
                table: "WorkInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "WorkInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "WorkInfos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WorkInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Cities_CityId",
                table: "WorkInfos",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Countries_CountryId",
                table: "WorkInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Departments_DepartmentId",
                table: "WorkInfos",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_JobTitles_JobTitleId",
                table: "WorkInfos",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Profiles_EmployeeId",
                table: "WorkInfos",
                column: "EmployeeId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Profiles_ManagerId",
                table: "WorkInfos",
                column: "ManagerId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Regions_RegionId",
                table: "WorkInfos",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Cities_CityId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Countries_CountryId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Departments_DepartmentId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_JobTitles_JobTitleId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Profiles_EmployeeId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Profiles_ManagerId",
                table: "WorkInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfos_Regions_RegionId",
                table: "WorkInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "WorkInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "WorkInfos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WorkInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "WorkInfos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkEmail",
                table: "WorkInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Cities_CityId",
                table: "WorkInfos",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Countries_CountryId",
                table: "WorkInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Departments_DepartmentId",
                table: "WorkInfos",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_JobTitles_JobTitleId",
                table: "WorkInfos",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Profiles_EmployeeId",
                table: "WorkInfos",
                column: "EmployeeId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Profiles_ManagerId",
                table: "WorkInfos",
                column: "ManagerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfos_Regions_RegionId",
                table: "WorkInfos",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
