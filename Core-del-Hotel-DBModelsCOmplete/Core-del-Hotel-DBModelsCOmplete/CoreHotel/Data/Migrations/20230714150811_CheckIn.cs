using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class CheckIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "check_In",
                table: "Reservaciones",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check_In",
                table: "Reservaciones");
        }
    }
}
