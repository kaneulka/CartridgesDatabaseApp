using Microsoft.EntityFrameworkCore.Migrations;

namespace Cartridges.Repo.Migrations
{
    public partial class addOtherBuildingNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherNames",
                table: "Building",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherNames",
                table: "Building");
        }
    }
}
