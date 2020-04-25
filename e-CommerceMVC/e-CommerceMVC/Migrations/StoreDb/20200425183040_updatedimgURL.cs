using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class updatedimgURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "Classic website", "https://imgur.com/ex7bvr4", "Classic", 150.00m, "12jrj830" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Hipster website", "https://imgur.com/KckYFPo", "Hipster" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Antique website", "https://imgur.com/rIRLFbX", "Antique" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Comical website", "https://imgur.com/xf5nzhK", "Comic" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Natural website", "https://imgur.com/1k8nogz", "Nature" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Technical website", "https://imgur.com/q1OefoY", "Technical" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Greyscale website", "https://imgur.com/lJrL4Sr", "Greyscale" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Cozy website", "https://imgur.com/ZesihIk", "Cozy" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Colorful website", "https://imgur.com/26bU5zY", "Colorful" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "Modern website", "https://imgur.com/G6NxY8n", "Modern", 200.00m, "8fj38s10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "very modern dumpster fires", "", "modern", 200.00m, "8fj38s10" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very hipster dumpster fires", "", "hipster" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very antique dumpster fires", "", "antique" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very comical dumpster fires", "", "comic" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very natural dumpster fires", "", "nature" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very technical dumpster fires", "", "technical" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very drab dumpster fires", "", "greyscale" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very cozy dumpster fires", "", "cozy" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "very colorful dumpster fires", "", "colorful" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "very classic dumpster fires", "", "classic", 150.00m, "12jrj830" });
        }
    }
}
