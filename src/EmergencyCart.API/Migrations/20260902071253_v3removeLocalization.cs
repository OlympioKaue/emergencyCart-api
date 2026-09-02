using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyCart.API.Migrations
{
    /// <inheritdoc />
    public partial class v3removeLocalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "EmergencyCart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "EmergencyCart",
                type: "VARCHAR(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
