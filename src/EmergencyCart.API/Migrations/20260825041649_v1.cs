using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyCart.API.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    Category = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    Hash = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    Role = table.Column<int>(type: "INT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    SectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyCart_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpectedQuantity = table.Column<int>(type: "INT", nullable: false),
                    EmergencyCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_EmergencyCart_EmergencyCartId",
                        column: x => x.EmergencyCartId,
                        principalTable: "EmergencyCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_EmergencyCartId",
                table: "CartItem",
                column: "EmergencyCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ItemId",
                table: "CartItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyCart_SectorId",
                table: "EmergencyCart",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "I_User_Email_Address",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EmergencyCart");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
