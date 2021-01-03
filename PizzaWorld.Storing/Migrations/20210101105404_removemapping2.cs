using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class removemapping2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stores_SelectedStoreEntityID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SelectedStoreEntityID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SelectedStoreEntityID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SelectedStoreEntityID",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityID",
                table: "Users",
                column: "SelectedStoreEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stores_SelectedStoreEntityID",
                table: "Users",
                column: "SelectedStoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
