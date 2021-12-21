using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pastebin.Migrations
{
    public partial class ExposureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionExposurePaste",
                table: "Pastes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionExposurePaste",
                table: "Pastes");
        }
    }
}
