using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class initialStore : Migration
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
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "A no nonsense design tailored to businesses with decerning taste. The Classic theme will allow your business to focus on what is important and not waste time with unnecessary features.", "https://i.imgur.com/ex7bvr4.jpg", "Classic", 1500.00m, "12jrj830" },
                    { 2, "Not your average design, be unique, be bold and carve your own path. The flexibility in this design will ensure no two are the same,so go ahead,and let your creativity show.", "https://i.imgur.com/KckYFPo.jpg", "Hipster", 3000.00m, "8fw4s10" },
                    { 3, "A classic design that is reminiscent of a by gone era. With a comprehensive and eloquently designed website, you will see an increase in positive user experiences, resulting in a better profit margin.", "https://i.imgur.com/rIRLFbX.jpg", "Antique", 1800.00m, "4nj38s10" },
                    { 4, "An exciting design for the hero in everyone. The comic design will allow the inner hero of your business to shine.Do not be fooled be the straightforward design, this layout packs a punch!", "https://i.imgur.com/xf5nzhK.jpg", "Comic", 2100.00m, "7mj38s10" },
                    { 5, "Get away from the hustle and bustle and take a deep breath. With a design that will make even the most adventurous feel right at home, this design is for those who are not afraid to get dirty and enjoy the great outdoors.", "https://i.imgur.com/1k8nogz.jpg", "Nature", 2000.00m, "12j38s10" },
                    { 6, "A design focused on showcasing technical data to convey your designs and all you to keep productive. With its straight forward layout you can spend less time fixing your site and more time being creative and doing what your passionate about.", "https://i.imgur.com/q1OefoY.jpg", "Technical", 2000.00m, "8fg38s10" },
                    { 7, "An elegant and minimalistic design to punctuate the things that are most important.This designs beauty is in its simplicity, when you need to present your site in a straightforward way this is the design to use.", "https://i.imgur.com/lJrL4Sr.jpg", "Greyscale", 1750.00m, "8fw8s10" },
                    { 8, "Like a warm fire, your favorite sweater or a home cooked meal, this design will make you feel right at home.So settle in and get cozy, this design will make you want to take it easy and spend some time to enjoy the simple things.", "https://i.imgur.com/ZesihIk.jpg", "Cozy", 1400.00m, "yv538s10" },
                    { 9, "with a well thought out design you are ensured to have a site that pops. Not afraid of a little color, go crazy with your palette and show the world how far a little color can go.", "https://i.imgur.com/26bU5zY.png", "Colorful", 1900.00m, "83nd8fn3" },
                    { 10, "Website that thrives in modern society and its fast changes. This website is for end user with modern taste and elegant details.", "https://i.imgur.com/aHUKS0C.png", "Modern", 2000.00m, "8fj38s10" }
                });

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
