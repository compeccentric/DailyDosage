using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyDosage.Data.Migrations
{
    public partial class categoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Categories_CategoryID",
                table: "Medications");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Medications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryName",
                table: "Medications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Categories_CategoryID",
                table: "Medications",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Categories_CategoryID",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Medications");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Medications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Categories_CategoryID",
                table: "Medications",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
