using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class settingvalues2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "Name",
                value: "regular");

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 2L,
                columns: new[] { "Name", "Price" },
                values: new object[] { "medium", 2.0 });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 3L,
                columns: new[] { "Name", "Price" },
                values: new object[] { "large", 3.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 1L,
                column: "Name",
                value: "small");

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 2L,
                columns: new[] { "Name", "Price" },
                values: new object[] { "large", 3.0 });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 3L,
                columns: new[] { "Name", "Price" },
                values: new object[] { "medium", 2.0 });
        }
    }
}
