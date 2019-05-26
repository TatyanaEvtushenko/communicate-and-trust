using Microsoft.EntityFrameworkCore.Migrations;

namespace CAT.DataLayer.Migrations
{
    public partial class AddEmotionTypetoTrainSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmotionType",
                table: "TrainingSessions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmotionType",
                table: "TrainingSessions");
        }
    }
}
