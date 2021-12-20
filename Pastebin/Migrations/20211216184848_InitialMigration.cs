using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pastebin.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pastes",
                columns: table => new
                {
                    PasteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordPaste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionExpirationPaste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTimeOfPaste = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasteCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exists = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastes", x => x.PasteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pastes");
        }
    }
}
