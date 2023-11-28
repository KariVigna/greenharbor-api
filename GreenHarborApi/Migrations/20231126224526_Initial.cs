using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHarborApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Composts",
                columns: table => new
                {
                    CompostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Zip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contents = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composts", x => x.CompostId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Composts",
                columns: new[] { "CompostId", "City", "ContactEmail", "ContactName", "ContactPhone", "Contents", "Location", "Zip" },
                values: new object[] { 1, null, "", "", "", "", "Near road marker 43, by the red barn", null });

            migrationBuilder.InsertData(
                table: "Composts",
                columns: new[] { "CompostId", "City", "ContactEmail", "ContactName", "ContactPhone", "Contents", "Location", "Zip" },
                values: new object[] { 2, null, "", "", "", "", "Past HR rd, end of the gravel driveway", null });

            migrationBuilder.InsertData(
                table: "Composts",
                columns: new[] { "CompostId", "City", "ContactEmail", "ContactName", "ContactPhone", "Contents", "Location", "Zip" },
                values: new object[] { 3, null, "", "", "", "", "Middle of town, near the post office", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Composts");
        }
    }
}
