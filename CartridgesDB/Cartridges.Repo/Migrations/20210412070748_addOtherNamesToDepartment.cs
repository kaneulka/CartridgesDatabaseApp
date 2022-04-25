using Microsoft.EntityFrameworkCore.Migrations;

namespace Cartridges.Repo.Migrations
{
    public partial class addOtherNamesToDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherNames",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherNames",
                table: "Department");
        }
    }
}
