using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.Grpc.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: ["Id", "Amount", "Description", "ProductName"],
                values: new object[,]
                {
                    { 1, 52, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Small Steel Ball" },
                    { 2, 14, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Awesome Metal Table" },
                    { 3, 76, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Awesome Cotton Bike" },
                    { 4, 53, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Intelligent Metal Table" },
                    { 5, 78, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Licensed Frozen Towels" },
                    { 6, 86, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Sleek Steel Fish" },
                    { 7, 65, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Incredible Steel Pants" },
                    { 8, 28, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Incredible Fresh Shirt" },
                    { 9, 74, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Licensed Steel Chicken" },
                    { 10, 79, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Unbranded Frozen Towels" },
                    { 11, 63, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Intelligent Wooden Table" },
                    { 12, 98, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Sleek Metal Towels" },
                    { 13, 87, "The Football Is Good For Training And Recreational Purposes", "Unbranded Metal Tuna" },
                    { 14, 87, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Handcrafted Metal Cheese" },
                    { 15, 12, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Sleek Concrete Chips" },
                    { 16, 88, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Licensed Soft Car" },
                    { 17, 57, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tasty Steel Hat" },
                    { 18, 35, "The Football Is Good For Training And Recreational Purposes", "Sleek Frozen Mouse" },
                    { 19, 90, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Sleek Soft Car" },
                    { 20, 72, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Handcrafted Steel Shirt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
