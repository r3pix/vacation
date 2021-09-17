using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacation.Migrations
{
    public partial class employmenttypeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmploymentType",
                table: "Users",
                newName: "EmploymentTypeId");

            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmploymentTypeId",
                table: "Users",
                column: "EmploymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmploymentTypes_EmploymentTypeId",
                table: "Users",
                column: "EmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmploymentTypes_EmploymentTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmploymentTypeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "EmploymentTypeId",
                table: "Users",
                newName: "EmploymentType");
        }
    }
}
