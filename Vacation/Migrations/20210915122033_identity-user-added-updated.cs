using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacation.Migrations
{
    public partial class identityuseraddedupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentityId",
                table: "Users",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Identities_IdentityId",
                table: "Users",
                column: "IdentityId",
                principalTable: "Identities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Identities_IdentityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdentityId",
                table: "Users");
        }
    }
}
