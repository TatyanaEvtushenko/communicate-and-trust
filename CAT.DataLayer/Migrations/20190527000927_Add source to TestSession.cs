using Microsoft.EntityFrameworkCore.Migrations;

namespace CAT.DataLayer.Migrations
{
    public partial class AddsourcetoTestSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "TestSessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "TestSessions");
        }
    }
}
