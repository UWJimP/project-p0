using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class removemapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Crust_CrustEntityID",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizza_PizzaEntityID",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crust",
                table: "Crust");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "Crust",
                newName: "Crusts");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_PizzaEntityID",
                table: "Toppings",
                newName: "IX_Toppings_PizzaEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts",
                column: "EntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crusts_CrustEntityID",
                table: "Pizza",
                column: "CrustEntityID",
                principalTable: "Crusts",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizza_PizzaEntityID",
                table: "Toppings",
                column: "PizzaEntityID",
                principalTable: "Pizza",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Crusts_CrustEntityID",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizza_PizzaEntityID",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "Crusts",
                newName: "Crust");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_PizzaEntityID",
                table: "Topping",
                newName: "IX_Topping_PizzaEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "EntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crust",
                table: "Crust",
                column: "EntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustEntityID",
                table: "Pizza",
                column: "CrustEntityID",
                principalTable: "Crust",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Pizza_PizzaEntityID",
                table: "Topping",
                column: "PizzaEntityID",
                principalTable: "Pizza",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
