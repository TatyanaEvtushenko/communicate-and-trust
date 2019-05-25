using Microsoft.EntityFrameworkCore.Migrations;

namespace CAT.DataLayer.Migrations
{
    public partial class AddIsReactiontoMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReaction",
                table: "Messages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReaction",
                table: "Messages");
        }
    }
}
