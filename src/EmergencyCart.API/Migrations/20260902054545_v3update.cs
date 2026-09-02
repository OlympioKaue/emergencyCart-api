using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyCart.API.Migrations
{
    /// <inheritdoc />
    public partial class v3update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Sector");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sector",
                type: "VARCHAR(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sector");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Sector",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Sector",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
