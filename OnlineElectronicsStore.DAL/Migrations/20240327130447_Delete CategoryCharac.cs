﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineElectronicsStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCategoryCharac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCharacteristics");

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CategoryCharacteristics",
                columns: table => new
                {
                    IdCategoryCharacteristic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdProductCharacteristic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCharacteristics", x => x.IdCategoryCharacteristic);
                    table.ForeignKey(
                        name: "FK_CategoryCharacteristics_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCharacteristics_ProductCharacteristics_IdProductCharacteristic",
                        column: x => x.IdProductCharacteristic,
                        principalTable: "ProductCharacteristics",
                        principalColumn: "IdProductCharacteristic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCharacteristics_IdCategory",
                table: "CategoryCharacteristics",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCharacteristics_IdProductCharacteristic",
                table: "CategoryCharacteristics",
                column: "IdProductCharacteristic");
        }
    }
}
