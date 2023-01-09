using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerStockApi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vitesse",
                table: "Processor",
                newName: "Vitesse");

            migrationBuilder.RenameColumn(
                name: "niveau",
                table: "Processor",
                newName: "Niveau");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProcessorId",
                table: "Computers",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_StateId",
                table: "Computers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_TypeId",
                table: "Computers",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ComputerType_TypeId",
                table: "Computers",
                column: "TypeId",
                principalTable: "ComputerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Processor_ProcessorId",
                table: "Computers",
                column: "ProcessorId",
                principalTable: "Processor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_State_StateId",
                table: "Computers",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ComputerType_TypeId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Processor_ProcessorId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_State_StateId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ProcessorId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_StateId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_TypeId",
                table: "Computers");

            migrationBuilder.RenameColumn(
                name: "Vitesse",
                table: "Processor",
                newName: "vitesse");

            migrationBuilder.RenameColumn(
                name: "Niveau",
                table: "Processor",
                newName: "niveau");
        }
    }
}
