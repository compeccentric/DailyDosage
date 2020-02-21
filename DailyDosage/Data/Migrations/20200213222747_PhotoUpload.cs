using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyDosage.Data.Migrations
{
    public partial class PhotoUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottlePhotoPath",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "PillPhotoPath",
                table: "Medications");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Medications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Medications");

            migrationBuilder.AddColumn<string>(
                name: "BottlePhotoPath",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PillPhotoPath",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
