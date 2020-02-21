using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyDosage.Data.Migrations
{
    public partial class AccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Medications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Medications");
        }
    }
}
