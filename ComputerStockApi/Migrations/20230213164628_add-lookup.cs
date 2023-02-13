using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class addlookup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "State" },
                values: new object[,]
                {
                    { 1, "In Stock" },
                    { 2, "Remote" },
                    { 3, "Office" },
                    { 4, "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
