using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuntodeVentaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisteredBoolean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Registered",
                table: "Sale",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Sale");
        }
    }
}
