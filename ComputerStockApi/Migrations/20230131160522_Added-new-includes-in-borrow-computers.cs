using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class Addednewincludesinborrowcomputers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BorrowComputer",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ComputerId",
                table: "BorrowComputer",
                newName: "ComputersId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowComputer_ComputersId",
                table: "BorrowComputer",
                column: "ComputersId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowComputer_UsersId",
                table: "BorrowComputer",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_Computers_ComputersId",
                table: "BorrowComputer",
                column: "ComputersId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_Users_UsersId",
                table: "BorrowComputer",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Computers_ComputersId",
                table: "BorrowComputer");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Users_UsersId",
                table: "BorrowComputer");

            migrationBuilder.DropIndex(
                name: "IX_BorrowComputer_ComputersId",
                table: "BorrowComputer");

            migrationBuilder.DropIndex(
                name: "IX_BorrowComputer_UsersId",
                table: "BorrowComputer");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "BorrowComputer",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ComputersId",
                table: "BorrowComputer",
                newName: "ComputerId");
        }
    }
}
