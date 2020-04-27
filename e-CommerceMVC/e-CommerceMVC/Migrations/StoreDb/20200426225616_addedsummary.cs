using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class addedsummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Website that is tailor to business with exquisite taste in classical theme. This outline will grab all of the antiquity enthusiast ");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Website that is designed for gen-z business owner. This site will captivate customers that favorites new trend.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Website that gear towards older generation customer. Very comprehensive and well designed website that will increase your profit immediately.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Website that is for comic fan user. This design will flourish with incoming traffic of comic and action hero lovers.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "Website that is one of our best seller. This nature design is sure to bring people who wants to be away from fast paced society and enjoy what nature has to offer.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "Website that aims to change and new things in the market. This website breathe in scalability and agile.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Description",
                value: "Website that is affordable and simple to user's eyes. The format is easy to follow and navigate.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Description",
                value: "Website that just looking at it brings coziness in your heart. Having this design will leave you with christmas everyday.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "Website that pursue on innovation and vibrant schema. This website illustrate all of the beautiful colors in the world into one. Sure to bring in heavy traffic.");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Website that thrives in modern society and its fast changes. This website is for end user with modern taste and elegant details.", "https://i.imgur.com/aHUKS0C.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Classic website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Hipster website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Antique website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Comical website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "Natural website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Description",
                value: "Technical website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Description",
                value: "Greyscale website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Description",
                value: "Cozy website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "Colorful website");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Modern website", "https://i.imgur.com/G6NxY8n.jpg" });
        }
    }
}
