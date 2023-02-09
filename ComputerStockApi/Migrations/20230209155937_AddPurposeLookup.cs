using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPurposeLookup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Purpose",
                columns: new[] { "Id", "Purpose" },
                values: new object[,]
                {
                    { 1, "Office" },
                    { 2, "Remote" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
