using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class removedpurpose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Purpose_PurposeId",
                table: "BorrowComputer");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropIndex(
                name: "IX_BorrowComputer_PurposeId",
                table: "BorrowComputer");

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

            migrationBuilder.DropColumn(
                name: "PurposeId",
                table: "BorrowComputer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurposeId",
                table: "BorrowComputer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Purpose",
                columns: new[] { "Id", "Purpose" },
                values: new object[,]
                {
                    { 1, "Office" },
                    { 2, "Remote" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "State" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Used" },
                    { 3, "Broken" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowComputer_PurposeId",
                table: "BorrowComputer",
                column: "PurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_Purpose_PurposeId",
                table: "BorrowComputer",
                column: "PurposeId",
                principalTable: "Purpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
