using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.Migrations.StoreDb
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "ID", "Email" },
                values: new object[] { 2, "bobR@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "A no nonsense design tailored to businesses with decerning taste. The Classic theme will allow your business to focus on what is important and not waste time with unnecessary features.", 1500.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Not your average design, be unique, be bold and carve your own path. The flexibility in this design will ensure no two are the same,so go ahead,and let your creativity show.", 3000.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Price" },
                values: new object[] { "A classic design that is reminiscent of a by gone era. With a comprehensive and eloquently designed website, you will see an increase in positive user experiences, resulting in a better profit margin.", 1800.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "An exciting design for the hero in everyone. The comic design will allow the inner hero of your business to shine.Do not be fooled be the straightforward design, this layout packs a punch!", 2100.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "Get away from the hustle and bustle and take a deep breath. With a design that will make even the most adventurous feel right at home, this design is for those who are not afraid to get dirty and enjoy the great outdoors.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Price" },
                values: new object[] { "A design focused on showcasing technical data to convey your designs and all you to keep productive. With its straight forward layout you can spend less time fixing your site and more time being creative and doing what your passionate about.", 2000.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Price" },
                values: new object[] { "An elegant and minimalistic design to punctuate the things that are most important.This designs beauty is in its simplicity, when you need to present your site in a straightforward way this is the design to use.", 1750.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Like a warm fire, your favorite sweater or a home cooked meal, this design will make you feel right at home.So settle in and get cozy, this design will make you want to take it easy and spend some time to enjoy the simple things.", 1400.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Price" },
                values: new object[] { "with a well thought out design you are ensured to have a site that pops. Not afraid of a little color, go crazy with your palette and show the world how far a little color can go.", 1900.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "Price",
                value: 2000.00m);

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ID", "CartsID", "ProductID", "Quantity" },
                values: new object[] { 2, 2, 5, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that is tailor to business with exquisite taste in classical theme. This outline will grab all of the antiquity enthusiast ", 150.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that is designed for gen-z business owner. This site will captivate customers that favorites new trend.", 300.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that gear towards older generation customer. Very comprehensive and well designed website that will increase your profit immediately.", 180.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that is for comic fan user. This design will flourish with incoming traffic of comic and action hero lovers.", 210.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "Website that is one of our best seller. This nature design is sure to bring people who wants to be away from fast paced society and enjoy what nature has to offer.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that aims to change and new things in the market. This website breathe in scalability and agile.", 200.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that is affordable and simple to user's eyes. The format is easy to follow and navigate.", 75.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that just looking at it brings coziness in your heart. Having this design will leave you with christmas everyday.", 240.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Website that pursue on innovation and vibrant schema. This website illustrate all of the beautiful colors in the world into one. Sure to bring in heavy traffic.", 350.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "Price",
                value: 200.00m);
        }
    }
}
