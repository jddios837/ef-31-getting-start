using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraApp.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClanDescription",
                table: "Clans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClanDescription",
                table: "Clans");
        }
    }
}
