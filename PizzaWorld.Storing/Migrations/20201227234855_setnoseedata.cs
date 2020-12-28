using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class setnoseedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "Crust",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pizza");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrustEntityID",
                table: "Pizza",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderEntityID",
                table: "Pizza",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizeEntityID",
                table: "Pizza",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaEntityID = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Topping_Pizza_PizzaEntityID",
                        column: x => x.PizzaEntityID,
                        principalTable: "Pizza",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustEntityID",
                table: "Pizza",
                column: "CrustEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderEntityID",
                table: "Pizza",
                column: "OrderEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeEntityID",
                table: "Pizza",
                column: "SizeEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_PizzaEntityID",
                table: "Topping",
                column: "PizzaEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustEntityID",
                table: "Pizza",
                column: "CrustEntityID",
                principalTable: "Crust",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Order_OrderEntityID",
                table: "Pizza",
                column: "OrderEntityID",
                principalTable: "Order",
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
                name: "FK_Pizza_Order_OrderEntityID",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Size_SizeEntityID",
                table: "Pizza");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_CrustEntityID",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_OrderEntityID",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_SizeEntityID",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CrustEntityID",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "OrderEntityID",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "SizeEntityID",
                table: "Pizza");

            migrationBuilder.AddColumn<string>(
                name: "Crust",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[] { 2L, "Store1" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[] { 3L, "Store2" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[] { 4L, "Store3" });
        }
    }
}
