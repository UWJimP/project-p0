using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class addpropertiestoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreEntityID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityID",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "UserEntityID",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityID",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreEntityID",
                table: "Order",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserEntityID",
                table: "Order",
                column: "UserEntityID",
                principalTable: "Users",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreEntityID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserEntityID",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "UserEntityID",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityID",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
