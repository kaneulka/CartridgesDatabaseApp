using Microsoft.EntityFrameworkCore.Migrations;

namespace Cartridges.Repo.Migrations
{
    public partial class AddFKinRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PrinterModelId",
                table: "Request",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Request_PrinterModelId",
                table: "Request",
                column: "PrinterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_PrinterModel_PrinterModelId",
                table: "Request",
                column: "PrinterModelId",
                principalTable: "PrinterModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_PrinterModel_PrinterModelId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_PrinterModelId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "PrinterModelId",
                table: "Request");
        }
    }
}
