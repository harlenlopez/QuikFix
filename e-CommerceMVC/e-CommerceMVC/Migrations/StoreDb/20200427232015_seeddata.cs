using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    CartsID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartsID",
                        column: x => x.CartsID,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "ID", "Email" },
                values: new object[] { 1, "Mochi@mochi.inc" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Website that is tailor to business with exquisite taste in classical theme. This outline will grab all of the antiquity enthusiast ", "https://i.imgur.com/ex7bvr4.jpg", "Classic", 150.00m, "12jrj830" },
                    { 2, "Website that is designed for gen-z business owner. This site will captivate customers that favorites new trend.", "https://i.imgur.com/KckYFPo.jpg", "Hipster", 300.00m, "8fw4s10" },
                    { 3, "Website that gear towards older generation customer. Very comprehensive and well designed website that will increase your profit immediately.", "https://i.imgur.com/rIRLFbX.jpg", "Antique", 180.00m, "4nj38s10" },
                    { 4, "Website that is for comic fan user. This design will flourish with incoming traffic of comic and action hero lovers.", "https://i.imgur.com/xf5nzhK.jpg", "Comic", 210.00m, "7mj38s10" },
                    { 5, "Website that is one of our best seller. This nature design is sure to bring people who wants to be away from fast paced society and enjoy what nature has to offer.", "https://i.imgur.com/1k8nogz.jpg", "Nature", 2000.00m, "12j38s10" },
                    { 6, "Website that aims to change and new things in the market. This website breathe in scalability and agile.", "https://i.imgur.com/q1OefoY.jpg", "Technical", 200.00m, "8fg38s10" },
                    { 7, "Website that is affordable and simple to user's eyes. The format is easy to follow and navigate.", "https://i.imgur.com/lJrL4Sr.jpg", "Greyscale", 75.00m, "8fw8s10" },
                    { 8, "Website that just looking at it brings coziness in your heart. Having this design will leave you with christmas everyday.", "https://i.imgur.com/ZesihIk.jpg", "Cozy", 240.00m, "yv538s10" },
                    { 9, "Website that pursue on innovation and vibrant schema. This website illustrate all of the beautiful colors in the world into one. Sure to bring in heavy traffic.", "https://i.imgur.com/26bU5zY.png", "Colorful", 350.00m, "83nd8fn3" },
                    { 10, "Website that thrives in modern society and its fast changes. This website is for end user with modern taste and elegant details.", "https://i.imgur.com/aHUKS0C.png", "Modern", 200.00m, "8fj38s10" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ID", "CartsID", "ProductID", "Quantity" },
                values: new object[] { 1, 1, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartsID",
                table: "CartItems",
                column: "CartsID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
