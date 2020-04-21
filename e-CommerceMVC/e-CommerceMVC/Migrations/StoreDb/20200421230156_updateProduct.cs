using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class updateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "very modern dumpster fires", "", "modern", 200.00m, "8fj38s10" },
                    { 2, "very hipster dumpster fires", "", "hipster", 300.00m, "8fw4s10" },
                    { 3, "very antique dumpster fires", "", "antique", 180.00m, "4nj38s10" },
                    { 4, "very comical dumpster fires", "", "comic", 210.00m, "7mj38s10" },
                    { 5, "very natural dumpster fires", "", "nature", 2000.00m, "12j38s10" },
                    { 6, "very technical dumpster fires", "", "technical", 200.00m, "8fg38s10" },
                    { 7, "very drab dumpster fires", "", "greyscale", 75.00m, "8fw8s10" },
                    { 8, "very cozy dumpster fires", "", "cozy", 240.00m, "yv538s10" },
                    { 9, "very colorful dumpster fires", "", "colorful", 350.00m, "83nd8fn3" },
                    { 10, "very classic dumpster fires", "", "classic", 150.00m, "12jrj830" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
