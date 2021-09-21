using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacation.Migrations
{
    public partial class database_edited_properties_renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleName",
                table: "JobTitles",
                newName: "JobTitleName");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "EmploymentTypes",
                newName: "EmploymentTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleName",
                table: "JobTitles",
                newName: "TitleName");

            migrationBuilder.RenameColumn(
                name: "EmploymentTypeName",
                table: "EmploymentTypes",
                newName: "Type");
        }
    }
}
