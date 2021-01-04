using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class addids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreEntityID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StoreEntityID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserEntityID",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 9L);

            migrationBuilder.DropColumn(
                name: "StoreEntityID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserEntityID",
                table: "Order");

            migrationBuilder.AddColumn<long>(
                name: "StoreID",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserID",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreID",
                table: "Order",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreID",
                table: "Order",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StoreID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Order");

            migrationBuilder.AddColumn<long>(
                name: "StoreEntityID",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserEntityID",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityID", "Name", "PizzaEntityID", "Price" },
                values: new object[,]
                {
                    { 1L, "cheese", null, 1.0 },
                    { 2L, "pepperoni", null, 0.75 },
                    { 3L, "sausage", null, 0.75 },
                    { 4L, "pineapple", null, 0.75 },
                    { 5L, "ham", null, 0.75 },
                    { 6L, "onion", null, 0.75 },
                    { 7L, "mushroom", null, 0.75 },
                    { 8L, "olive", null, 0.75 },
                    { 9L, "sauce", null, 2.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityID",
                table: "Order",
                column: "StoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserEntityID",
                table: "Order",
                column: "UserEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreEntityID",
                table: "Order",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserEntityID",
                table: "Order",
                column: "UserEntityID",
                principalTable: "Users",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
