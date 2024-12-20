using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group_8.Migrations
{
    /// <inheritdoc />
    public partial class FixedAllClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryHistory_AspNetUsers_ManagerId",
                table: "InventoryHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_ManagerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_SmallBusinessOwnerId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_RestockOrder_Supplier_SupplierID",
                table: "RestockOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_SmallBusinessOwnerId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_StaffId1",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetail_Sale_SaleID",
                table: "SaleDetail");

            migrationBuilder.DropIndex(
                name: "IX_Sale_SmallBusinessOwnerId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_StaffId1",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Product_ManagerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SmallBusinessOwnerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_InventoryHistory_ManagerId",
                table: "InventoryHistory");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SaleTime",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SmallBusinessOwnerId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "StaffId1",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SmallBusinessOwnerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "InventoryHistory");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Supplier",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "SaleID",
                table: "SaleDetail",
                newName: "SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetail_SaleID",
                table: "SaleDetail",
                newName: "IX_SaleDetail_SaleId");

            migrationBuilder.RenameColumn(
                name: "SaleID",
                table: "Sale",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sale",
                newName: "SaleDateTime");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "RestockOrder",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_RestockOrder_SupplierID",
                table: "RestockOrder",
                newName: "IX_RestockOrder_SupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Sale",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "RestockOrder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_StaffId",
                table: "Sale",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_RestockOrder_ManagerId",
                table: "RestockOrder",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestockOrder_AspNetUsers_ManagerId",
                table: "RestockOrder",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestockOrder_Supplier_SupplierId",
                table: "RestockOrder",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_StaffId",
                table: "Sale",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetail_Sale_SaleId",
                table: "SaleDetail",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestockOrder_AspNetUsers_ManagerId",
                table: "RestockOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RestockOrder_Supplier_SupplierId",
                table: "RestockOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_StaffId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetail_Sale_SaleId",
                table: "SaleDetail");

            migrationBuilder.DropIndex(
                name: "IX_Sale_StaffId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_RestockOrder_ManagerId",
                table: "RestockOrder");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "RestockOrder");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Supplier",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "SaleDetail",
                newName: "SaleID");

            migrationBuilder.RenameIndex(
                name: "IX_SaleDetail_SaleId",
                table: "SaleDetail",
                newName: "IX_SaleDetail_SaleID");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "Sale",
                newName: "SaleID");

            migrationBuilder.RenameColumn(
                name: "SaleDateTime",
                table: "Sale",
                newName: "SaleDate");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "RestockOrder",
                newName: "SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_RestockOrder_SupplierId",
                table: "RestockOrder",
                newName: "IX_RestockOrder_SupplierID");

            migrationBuilder.AlterColumn<int>(
                name: "SaleID",
                table: "SaleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SaleTime",
                table: "Sale",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "SmallBusinessOwnerId",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffId1",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallBusinessOwnerId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "InventoryHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_SmallBusinessOwnerId",
                table: "Sale",
                column: "SmallBusinessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_StaffId1",
                table: "Sale",
                column: "StaffId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManagerId",
                table: "Product",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SmallBusinessOwnerId",
                table: "Product",
                column: "SmallBusinessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_ManagerId",
                table: "InventoryHistory",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ManagerId",
                table: "AspNetUsers",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryHistory_AspNetUsers_ManagerId",
                table: "InventoryHistory",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_ManagerId",
                table: "Product",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_SmallBusinessOwnerId",
                table: "Product",
                column: "SmallBusinessOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestockOrder_Supplier_SupplierID",
                table: "RestockOrder",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_SmallBusinessOwnerId",
                table: "Sale",
                column: "SmallBusinessOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_StaffId1",
                table: "Sale",
                column: "StaffId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetail_Sale_SaleID",
                table: "SaleDetail",
                column: "SaleID",
                principalTable: "Sale",
                principalColumn: "SaleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
