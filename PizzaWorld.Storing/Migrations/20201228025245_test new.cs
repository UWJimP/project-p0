using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class testnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "regular", 1.0 },
                    { 2L, "thin", 1.5 },
                    { 3L, "pan", 1.75 }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "EntityID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "small", 1.0 },
                    { 3L, "medium", 2.0 },
                    { 2L, "large", 3.0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[,]
                {
                    { 3L, "Papa John's" },
                    { 4L, "Generic Pizza Place" },
                    { 1L, "Domino's" },
                    { 2L, "Pizza Hut" }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "EntityID", "Name", "PizzaEntityID", "Price" },
                values: new object[,]
                {
                    { 8L, "olive", null, 0.75 },
                    { 1L, "cheese", null, 1.0 },
                    { 2L, "pepperoni", null, 0.75 },
                    { 3L, "sausage", null, 0.75 },
                    { 4L, "pineapple", null, 0.75 },
                    { 5L, "ham", null, 0.75 },
                    { 6L, "onion", null, 0.75 },
                    { 7L, "mushroom", null, 0.75 },
                    { 9L, "sauce", null, 2.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 1L);

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

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityID",
                keyValue: 9L);
        }
    }
}
