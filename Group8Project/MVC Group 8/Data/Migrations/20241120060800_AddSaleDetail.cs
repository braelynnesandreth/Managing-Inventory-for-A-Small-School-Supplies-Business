using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group_8.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing ProductId from Sale table
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ProductId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sale");

            // Create the SaleDetail table
            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Add indexes for SaleDetail table
            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId",
                table: "SaleDetail",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ProductId",
                table: "SaleDetail",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the SaleDetail table
            migrationBuilder.DropTable(
                name: "SaleDetail");

            // Re-add the ProductId to the Sale table
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductId",
                table: "Sale",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}