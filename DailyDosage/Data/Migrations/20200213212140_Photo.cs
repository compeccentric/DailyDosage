using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyDosage.Data.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BottlePhotoPath",
                table: "Medications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PillPhotoPath",
                table: "Medications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottlePhotoPath",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "PillPhotoPath",
                table: "Medications");
        }
    }
}
