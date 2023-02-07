using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPurposeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "BorrowComputer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PurposeId",
                table: "BorrowComputer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PurposeDao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeDao", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ComputerType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "PC");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowComputer_PurposeId",
                table: "BorrowComputer",
                column: "PurposeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_PurposeDao_PurposeId",
                table: "BorrowComputer",
                column: "PurposeId",
                principalTable: "PurposeDao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_PurposeDao_PurposeId",
                table: "BorrowComputer");

            migrationBuilder.DropTable(
                name: "PurposeDao");

            migrationBuilder.DropIndex(
                name: "IX_BorrowComputer_PurposeId",
                table: "BorrowComputer");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "BorrowComputer");

            migrationBuilder.DropColumn(
                name: "PurposeId",
                table: "BorrowComputer");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ComputerType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Fix");
        }
    }
}
