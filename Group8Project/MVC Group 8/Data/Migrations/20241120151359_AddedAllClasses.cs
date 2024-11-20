using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group_8.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the Supplier table
            migrationBuilder.CreateTable(
    name: "Supplier",
    columns: table => new
    {
        SupplierId = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Name = table.Column<string>(type: "nvarchar(255)", nullable: false),  // Changed to a fixed length
        ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Supplier", x => x.SupplierId);
    });

            // Create the Product table
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create the Sale table
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sale_AspNetUsers_StaffId1",
                        column: x => x.StaffId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            // Create the RestockOrder table
            migrationBuilder.CreateTable(
                name: "RestockOrder",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestockOrder", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_RestockOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RestockOrder_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.NoAction);
                });

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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create indexes for each table
            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Name",
                table: "Supplier",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RestockOrder_ProductId",
                table: "RestockOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RestockOrder_SupplierId",
                table: "RestockOrder",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_StaffId1",
                table: "Sale",
                column: "StaffId1");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ProductId",
                table: "SaleDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId",
                table: "SaleDetail",
                column: "SaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the indexes first to avoid conflicts with foreign key constraints
            migrationBuilder.DropIndex(name: "IX_SaleDetail_SaleId", table: "SaleDetail");
            migrationBuilder.DropIndex(name: "IX_SaleDetail_ProductId", table: "SaleDetail");
            migrationBuilder.DropIndex(name: "IX_Sale_StaffId1", table: "Sale");
            migrationBuilder.DropIndex(name: "IX_RestockOrder_SupplierId", table: "RestockOrder");
            migrationBuilder.DropIndex(name: "IX_RestockOrder_ProductId", table: "RestockOrder");
            migrationBuilder.DropIndex(name: "IX_Product_SupplierId", table: "Product");
            migrationBuilder.DropIndex(name: "IX_Supplier_Name", table: "Supplier");

            // Drop the tables in reverse order of creation
            migrationBuilder.DropTable(name: "SaleDetail");
            migrationBuilder.DropTable(name: "Sale");
            migrationBuilder.DropTable(name: "RestockOrder");
            migrationBuilder.DropTable(name: "Product");
            migrationBuilder.DropTable(name: "Supplier");
        }
    }
}

