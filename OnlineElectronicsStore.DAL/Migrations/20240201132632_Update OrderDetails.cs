using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineElectronicsStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Orders_IdOrder",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_IdProduct",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "IdOrderDetail",
                table: "OrderDetails",
                newName: "IdOrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_IdProduct",
                table: "OrderDetails",
                newName: "IX_OrderDetails_IdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_IdOrder",
                table: "OrderDetails",
                newName: "IX_OrderDetails_IdOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "IdOrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_IdOrder",
                table: "OrderDetails",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_IdProduct",
                table: "OrderDetails",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_IdOrder",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_IdProduct",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "IdOrderDetails",
                table: "OrderDetail",
                newName: "IdOrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_IdProduct",
                table: "OrderDetail",
                newName: "IX_OrderDetail_IdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_IdOrder",
                table: "OrderDetail",
                newName: "IX_OrderDetail_IdOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "IdOrderDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Orders_IdOrder",
                table: "OrderDetail",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_IdProduct",
                table: "OrderDetail",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
