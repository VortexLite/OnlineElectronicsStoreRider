using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineElectronicsStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Addnavigationtable : Migration
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
                name: "Description",
                table: "Products",
                newName: "LongDescription");

            migrationBuilder.RenameColumn(
                name: "TotalCose",
                table: "Orders",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "DateOrder");

            migrationBuilder.RenameColumn(
                name: "IdOrderDetails",
                table: "OrderDetails",
                newName: "IdOrderDetail");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Navigations",
                columns: table => new
                {
                    IdNavigation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdProducer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigations", x => x.IdNavigation);
                    table.ForeignKey(
                        name: "FK_Navigations_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Navigations_Producers_IdProducer",
                        column: x => x.IdProducer,
                        principalTable: "Producers",
                        principalColumn: "IdProducer",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Navigations_IdCategory",
                table: "Navigations",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Navigations_IdProducer",
                table: "Navigations",
                column: "IdProducer");

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
                name: "Navigations");

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

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LongDescription",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Orders",
                newName: "TotalCose");

            migrationBuilder.RenameColumn(
                name: "DateOrder",
                table: "Orders",
                newName: "Date");

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
