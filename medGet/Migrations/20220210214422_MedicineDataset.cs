using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medGet.Migrations
{
    public partial class MedicineDataset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Generic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDetails");
        }
    }
}
