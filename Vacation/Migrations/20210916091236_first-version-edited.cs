using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacation.Migrations
{
    public partial class firstversionedited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Identities_IdentityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Identities");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdentityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "IdentityId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Identities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identities", x => x.Id);
                });

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
    }
}
