using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class testgetsizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Size_SizeEntityID",
                table: "Pizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "EntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Sizes_SizeEntityID",
                table: "Pizza",
                column: "SizeEntityID",
                principalTable: "Sizes",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Sizes_SizeEntityID",
                table: "Pizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "EntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Size_SizeEntityID",
                table: "Pizza",
                column: "SizeEntityID",
                principalTable: "Size",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
