using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group_8.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProductAssociations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InventoryHistory_ProductId",
                table: "InventoryHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_ProductId",
                table: "InventoryHistory",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InventoryHistory_ProductId",
                table: "InventoryHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_ProductId",
                table: "InventoryHistory",
                column: "ProductId",
                unique: true);
        }
    }
}
