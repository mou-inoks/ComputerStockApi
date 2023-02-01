using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class removedsfromcomputerdao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Computers_ComputersId",
                table: "BorrowComputer");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Users_UsersId",
                table: "BorrowComputer");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "BorrowComputer",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ComputersId",
                table: "BorrowComputer",
                newName: "ComputerId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowComputer_UsersId",
                table: "BorrowComputer",
                newName: "IX_BorrowComputer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowComputer_ComputersId",
                table: "BorrowComputer",
                newName: "IX_BorrowComputer_ComputerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_Computers_ComputerId",
                table: "BorrowComputer",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowComputer_Users_UserId",
                table: "BorrowComputer",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Computers_ComputerId",
                table: "BorrowComputer");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowComputer_Users_UserId",
                table: "BorrowComputer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BorrowComputer",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ComputerId",
                table: "BorrowComputer",
                newName: "ComputersId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowComputer_UserId",
                table: "BorrowComputer",
                newName: "IX_BorrowComputer_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowComputer_ComputerId",
                table: "BorrowComputer",
                newName: "IX_BorrowComputer_ComputersId");

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
    }
}
