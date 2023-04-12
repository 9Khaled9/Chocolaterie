using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chocolaterie.Migrations
{
    /// <inheritdoc />
    public partial class AdjustEntitiesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChocolateBar_Factories_FactoryId",
                table: "ChocolateBar");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Discount_DiscountId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_WholeSaler_WholeSalerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Stock_StockId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_ChocolateBar_ChocolateBarId",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_WholeSaler_WholeSalerId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WholeSaler",
                table: "WholeSaler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChocolateBar",
                table: "ChocolateBar");

            migrationBuilder.RenameTable(
                name: "WholeSaler",
                newName: "WholeSalers");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "OrderLines");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "ChocolateBar",
                newName: "ChocolateBars");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_WholeSalerId",
                table: "Stocks",
                newName: "IX_Stocks_WholeSalerId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_ChocolateBarId",
                table: "Stocks",
                newName: "IX_Stocks_ChocolateBarId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_StockId",
                table: "OrderLines",
                newName: "IX_OrderLines_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLines",
                newName: "IX_OrderLines_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_WholeSalerId",
                table: "Orders",
                newName: "IX_Orders_WholeSalerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DiscountId",
                table: "Orders",
                newName: "IX_Orders_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ChocolateBar_FactoryId",
                table: "ChocolateBars",
                newName: "IX_ChocolateBars_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WholeSalers",
                table: "WholeSalers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChocolateBars",
                table: "ChocolateBars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChocolateBars_Factories_FactoryId",
                table: "ChocolateBars",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Stocks_StockId",
                table: "OrderLines",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WholeSalers_WholeSalerId",
                table: "Orders",
                column: "WholeSalerId",
                principalTable: "WholeSalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ChocolateBars_ChocolateBarId",
                table: "Stocks",
                column: "ChocolateBarId",
                principalTable: "ChocolateBars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_WholeSalers_WholeSalerId",
                table: "Stocks",
                column: "WholeSalerId",
                principalTable: "WholeSalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChocolateBars_Factories_FactoryId",
                table: "ChocolateBars");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Stocks_StockId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WholeSalers_WholeSalerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ChocolateBars_ChocolateBarId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_WholeSalers_WholeSalerId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WholeSalers",
                table: "WholeSalers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChocolateBars",
                table: "ChocolateBars");

            migrationBuilder.RenameTable(
                name: "WholeSalers",
                newName: "WholeSaler");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderLines",
                newName: "OrderLine");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "ChocolateBars",
                newName: "ChocolateBar");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_WholeSalerId",
                table: "Stock",
                newName: "IX_Stock_WholeSalerId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ChocolateBarId",
                table: "Stock",
                newName: "IX_Stock_ChocolateBarId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_WholeSalerId",
                table: "Order",
                newName: "IX_Order_WholeSalerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DiscountId",
                table: "Order",
                newName: "IX_Order_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_StockId",
                table: "OrderLine",
                newName: "IX_OrderLine_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChocolateBars_FactoryId",
                table: "ChocolateBar",
                newName: "IX_ChocolateBar_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WholeSaler",
                table: "WholeSaler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChocolateBar",
                table: "ChocolateBar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChocolateBar_Factories_FactoryId",
                table: "ChocolateBar",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Discount_DiscountId",
                table: "Order",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_WholeSaler_WholeSalerId",
                table: "Order",
                column: "WholeSalerId",
                principalTable: "WholeSaler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Stock_StockId",
                table: "OrderLine",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_ChocolateBar_ChocolateBarId",
                table: "Stock",
                column: "ChocolateBarId",
                principalTable: "ChocolateBar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_WholeSaler_WholeSalerId",
                table: "Stock",
                column: "WholeSalerId",
                principalTable: "WholeSaler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
