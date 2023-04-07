using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuntodeVentaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddClosedBoolean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "PartialClosure",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "PartialClosure");
        }
    }
}
