using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacation.Migrations
{
    public partial class listofpresence_place_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "ListOfPresences",
                newName: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfPresences_UserId",
                table: "ListOfPresences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfPresences_Users_UserId",
                table: "ListOfPresences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfPresences_Users_UserId",
                table: "ListOfPresences");

            migrationBuilder.DropIndex(
                name: "IX_ListOfPresences_UserId",
                table: "ListOfPresences");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ListOfPresences",
                newName: "Time");
        }
    }
}
