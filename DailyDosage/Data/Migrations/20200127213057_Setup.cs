using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyDosage.Data.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dosage = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    MondayMorn = table.Column<bool>(nullable: false),
                    MondayAfter = table.Column<bool>(nullable: false),
                    MondayEve = table.Column<bool>(nullable: false),
                    TuesdayMorn = table.Column<bool>(nullable: false),
                    TuesdayAfter = table.Column<bool>(nullable: false),
                    TuesdayEve = table.Column<bool>(nullable: false),
                    WednesdayMorn = table.Column<bool>(nullable: false),
                    WednesdayAfter = table.Column<bool>(nullable: false),
                    WednesdayEve = table.Column<bool>(nullable: false),
                    ThursdayMorn = table.Column<bool>(nullable: false),
                    ThursdayAfter = table.Column<bool>(nullable: false),
                    ThursdayEve = table.Column<bool>(nullable: false),
                    FridayMorn = table.Column<bool>(nullable: false),
                    FridayAfter = table.Column<bool>(nullable: false),
                    FridayEve = table.Column<bool>(nullable: false),
                    SaturdayMorn = table.Column<bool>(nullable: false),
                    SaturdayAfter = table.Column<bool>(nullable: false),
                    SaturdayEve = table.Column<bool>(nullable: false),
                    SundayMorn = table.Column<bool>(nullable: false),
                    SundayAfter = table.Column<bool>(nullable: false),
                    SundayEve = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medications_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_CategoryID",
                table: "Medications",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
