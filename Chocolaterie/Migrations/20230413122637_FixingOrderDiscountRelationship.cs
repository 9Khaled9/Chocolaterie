using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chocolaterie.Migrations
{
    /// <inheritdoc />
    public partial class FixingOrderDiscountRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AboveConstraint", "Description", "Percentage", "Title" },
                values: new object[] { 0, "No discount is applied", 0.0, "discount 0%" });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AboveConstraint", "Description", "Percentage", "Title" },
                values: new object[] { 10, "A 10% discount is applied above 10 chocolate bars", 10.0, "discount 10%" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "AboveConstraint", "Description", "IsDeleted", "Percentage", "Title" },
                values: new object[] { 3, 20, "A 20% discount is applied above 20 chocolate bars", false, 20.0, "discount 20%" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AboveConstraint", "Description", "Percentage", "Title" },
                values: new object[] { 10, "A 10% discount is applied above 10 chocolate bars", 10.0, "discount 10%" });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AboveConstraint", "Description", "Percentage", "Title" },
                values: new object[] { 20, "A 20% discount is applied above 20 chocolate bars", 20.0, "discount 20%" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
