using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyCart.API.Migrations
{
    /// <inheritdoc />
    public partial class hasSequencyDbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "EmergencyCartCodeSequence",
                schema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "EmergencyCartCodeSequence",
                schema: "dbo");
        }
    }
}
