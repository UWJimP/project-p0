using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class testnewpizzacontextforseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Crust_CrustID",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Size_SizeID",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "SizeID",
                table: "Pizza",
                newName: "SizeEntityID");

            migrationBuilder.RenameColumn(
                name: "CrustID",
                table: "Pizza",
                newName: "CrustEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_SizeID",
                table: "Pizza",
                newName: "IX_Pizza_SizeEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_CrustID",
                table: "Pizza",
                newName: "IX_Pizza_CrustEntityID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustEntityID",
                table: "Pizza",
                column: "CrustEntityID",
                principalTable: "Crust",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Size_SizeEntityID",
                table: "Pizza",
                column: "SizeEntityID",
                principalTable: "Size",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Crust_CrustEntityID",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Size_SizeEntityID",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "SizeEntityID",
                table: "Pizza",
                newName: "SizeID");

            migrationBuilder.RenameColumn(
                name: "CrustEntityID",
                table: "Pizza",
                newName: "CrustID");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_SizeEntityID",
                table: "Pizza",
                newName: "IX_Pizza_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_CrustEntityID",
                table: "Pizza",
                newName: "IX_Pizza_CrustID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustID",
                table: "Pizza",
                column: "CrustID",
                principalTable: "Crust",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Size_SizeID",
                table: "Pizza",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
