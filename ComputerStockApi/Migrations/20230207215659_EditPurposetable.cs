using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class EditPurposetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_PurposeDao_PurposeId",
                table: "BorrowComputer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurposeDao",
                table: "PurposeDao");

            migrationBuilder.RenameTable(
                name: "PurposeDao",
                newName: "Purpose");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purpose",
                table: "Purpose",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_Purpose_PurposeId",
                table: "BorrowComputer",
                column: "PurposeId",
                principalTable: "Purpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Purpose_PurposeId",
                table: "BorrowComputer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purpose",
                table: "Purpose");

            migrationBuilder.RenameTable(
                name: "Purpose",
                newName: "PurposeDao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurposeDao",
                table: "PurposeDao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_PurposeDao_PurposeId",
                table: "BorrowComputer",
                column: "PurposeId",
                principalTable: "PurposeDao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
