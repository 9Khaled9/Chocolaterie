using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chocolaterie.Migrations
{
    /// <inheritdoc />
    public partial class AllEntitiesRelationships_IsDeleted_ContactInfo_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Factories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Factories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Factories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Factories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChocolateBars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WholeSalers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholeSalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<int>(type: "int", nullable: false),
                    TotalAfterDiscount = table.Column<int>(type: "int", nullable: false),
                    WholeSalerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_WholeSalers_WholeSalerId",
                        column: x => x.WholeSalerId,
                        principalTable: "WholeSalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChocolateBarId = table.Column<int>(type: "int", nullable: false),
                    WholeSalerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_ChocolateBars_ChocolateBarId",
                        column: x => x.ChocolateBarId,
                        principalTable: "ChocolateBars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_WholeSalers_WholeSalerId",
                        column: x => x.WholeSalerId,
                        principalTable: "WholeSalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Contact", "Description", "Email", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "", "", "Hoz Market", "", false, "Hoz Market" },
                    { 2, "", "", "spinneys", "", false, "spinneys" },
                    { 3, "", "", "mcdonald's", "", false, "mcdonald's" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Description", "IsDeleted", "Percentage", "Title" },
                values: new object[,]
                {
                    { 1, "A 10% discount is applied above 10 chocolate bars", false, 10.0, "discount 10%" },
                    { 2, "A 20% discount is applied above 20 chocolate bars", false, 20.0, "discount 20%" }
                });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "Id", "Address", "Contact", "Email", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "", "", "", false, "Neuhaus" },
                    { 2, "", "", "", false, "Ghandour" },
                    { 3, "", "", "", false, "Torku" }
                });

            migrationBuilder.InsertData(
                table: "WholeSalers",
                columns: new[] { "Id", "Address", "Contact", "Description", "Email", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "RUE DE LA PRINCESSE, 7100 TRIVIÈRES, BELGIUM", "+32 472 08 77 16", "SOUTH EXPORT ALLIANCE - Produits alimentaires et non alimentaires asiatiques authentiques", "info@sealliance.be", false, "SEA" },
                    { 2, "MEGAFORM AG - Rue Haute, 177 - 4700 EUPEN Belgium", "+32 87 32 17 18", "MEGAFORM - Innovative and educational products for physical education distributors", "info@megaform.com", false, "MEGAFORM" },
                    { 3, "Kwikaard 104 - 2980 Zoersel - Belgium", "+32 (0)3 385 58 28", "AFRIMEX BELGIUM - For those who choose quality", "info@afrimex.be", false, "AFRIMEX BELGIUM" }
                });

            migrationBuilder.InsertData(
                table: "ChocolateBars",
                columns: new[] { "Id", "Description", "FactoryId", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "SPRING BALLOTIN 1/4 LB 10 PCS", 1, false, "SPRING BALLOTIN 1/4 LB 10 PCS", 24.899999999999999 },
                    { 2, "CLASSIC BALLOTIN 0.25 LB", 1, false, "CLASSIC BALLOTIN 0.25 LB", 24.899999999999999 },
                    { 3, "LOVE BALLOTIN 1 LB", 1, false, "LOVE BALLOTIN 1 LB", 78.900000000000006 },
                    { 4, "Gandour Digestive Chocolate Biscuits are sprinkled with chocolate chips, which is also its most prominent distinguishing ingredient.", 2, false, "Digestive", 18.5 },
                    { 5, "Creamy Hazelnut", 2, false, "Unica", 10.5 },
                    { 6, "Chewy Caramel", 2, false, "Pik-One", 10.5 },
                    { 7, "Torku Classic Chocolate Series (Dark Chocolate (60% Cacao )", 3, false, "Bitter Cikolata", 56.0 },
                    { 8, "White Chocolate With Cocoa Hazelnut Cream Filling", 3, false, "Gold", 28.5 },
                    { 9, "Torku Çokofest Caramel Filled Milk Chocolate 60 gr", 3, false, "Çokofest", 55.899999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ChocolateBarId", "Description", "IsDeleted", "Quatity", "WholeSalerId" },
                values: new object[,]
                {
                    { 1, 1, "", false, 50, 1 },
                    { 2, 2, "", false, 50, 1 },
                    { 3, 3, "", false, 50, 1 },
                    { 4, 4, "", false, 50, 1 },
                    { 5, 5, "", false, 50, 1 },
                    { 6, 6, "", false, 50, 1 },
                    { 7, 7, "", false, 50, 1 },
                    { 8, 8, "", false, 50, 1 },
                    { 9, 9, "", false, 50, 1 },
                    { 10, 1, "", false, 50, 2 },
                    { 11, 2, "", false, 50, 2 },
                    { 12, 3, "", false, 50, 2 },
                    { 13, 4, "", false, 50, 2 },
                    { 14, 5, "", false, 50, 2 },
                    { 15, 6, "", false, 50, 2 },
                    { 16, 7, "", false, 50, 3 },
                    { 17, 8, "", false, 50, 3 },
                    { 18, 9, "", false, 50, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_StockId",
                table: "OrderLines",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WholeSalerId",
                table: "Orders",
                column: "WholeSalerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ChocolateBarId",
                table: "Stocks",
                column: "ChocolateBarId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_WholeSalerId",
                table: "Stocks",
                column: "WholeSalerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "WholeSalers");

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ChocolateBars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChocolateBars");
        }
    }
}
