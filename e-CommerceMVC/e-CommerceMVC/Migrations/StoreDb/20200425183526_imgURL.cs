using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class imgURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "https://i.imgur.com/ex7bvr4.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "https://i.imgur.com/KckYFPo.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "https://i.imgur.com/rIRLFbX.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "https://i.imgur.com/xf5nzhK.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "https://i.imgur.com/1k8nogz.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "https://i.imgur.com/q1OefoY.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "https://i.imgur.com/lJrL4Sr.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "https://i.imgur.com/ZesihIk.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "https://i.imgur.com/26bU5zY.png");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "https://i.imgur.com/G6NxY8n.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "https://imgur.com/ex7bvr4");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "https://imgur.com/KckYFPo");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "https://imgur.com/rIRLFbX");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "https://imgur.com/xf5nzhK");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "https://imgur.com/1k8nogz");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "https://imgur.com/q1OefoY");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "https://imgur.com/lJrL4Sr");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "https://imgur.com/ZesihIk");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "https://imgur.com/26bU5zY");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "https://imgur.com/G6NxY8n");
        }
    }
}
