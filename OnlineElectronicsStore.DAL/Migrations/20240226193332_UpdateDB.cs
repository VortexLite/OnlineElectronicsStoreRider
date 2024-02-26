using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineElectronicsStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_IdProfile",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdDeliveryType",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalCose",
                table: "Orders",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "IdOrderDetails",
                table: "OrderDetails",
                newName: "IdOrderDetail");

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    IdWishList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.IdWishList);
                    table.ForeignKey(
                        name: "FK_WishLists_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWishLists",
                columns: table => new
                {
                    IdProductWishList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdWishList = table.Column<int>(type: "int", nullable: false),
                    idProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishLists", x => x.IdProductWishList);
                    table.ForeignKey(
                        name: "FK_ProductWishLists_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWishLists_WishLists_IdWishList",
                        column: x => x.IdWishList,
                        principalTable: "WishLists",
                        principalColumn: "IdWishList",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfile",
                table: "Users",
                column: "IdProfile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdDeliveryType",
                table: "Orders",
                column: "IdDeliveryType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishLists_idProduct",
                table: "ProductWishLists",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishLists_IdWishList",
                table: "ProductWishLists",
                column: "IdWishList");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_IdUser",
                table: "WishLists",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWishLists");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdProfile",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdDeliveryType",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Orders",
                newName: "TotalCose");

            migrationBuilder.RenameColumn(
                name: "IdOrderDetail",
                table: "OrderDetails",
                newName: "IdOrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfile",
                table: "Users",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdDeliveryType",
                table: "Orders",
                column: "IdDeliveryType");
        }
    }
}
