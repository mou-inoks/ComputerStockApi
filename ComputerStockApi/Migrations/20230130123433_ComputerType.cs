using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class ComputerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComputerType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Mini-Computer" },
                    { 3, "Fix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComputerType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComputerType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComputerType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
