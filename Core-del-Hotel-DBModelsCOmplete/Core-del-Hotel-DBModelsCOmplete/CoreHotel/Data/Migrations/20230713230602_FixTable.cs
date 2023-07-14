using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosFactura_Huesped_Id_Huesped",
                table: "ServiciosFactura");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "ServiciosFactura");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "ServiciosFactura");

            migrationBuilder.RenameColumn(
                name: "Id_Huesped",
                table: "ServiciosFactura",
                newName: "Id_Factura");

            migrationBuilder.RenameIndex(
                name: "IX_ServiciosFactura_Id_Huesped",
                table: "ServiciosFactura",
                newName: "IX_ServiciosFactura_Id_Factura");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosFactura_Facturas_Id_Factura",
                table: "ServiciosFactura",
                column: "Id_Factura",
                principalTable: "Facturas",
                principalColumn: "Id_Factura",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosFactura_Facturas_Id_Factura",
                table: "ServiciosFactura");

            migrationBuilder.RenameColumn(
                name: "Id_Factura",
                table: "ServiciosFactura",
                newName: "Id_Huesped");

            migrationBuilder.RenameIndex(
                name: "IX_ServiciosFactura_Id_Factura",
                table: "ServiciosFactura",
                newName: "IX_ServiciosFactura_Id_Huesped");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "ServiciosFactura",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "precio",
                table: "ServiciosFactura",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosFactura_Huesped_Id_Huesped",
                table: "ServiciosFactura",
                column: "Id_Huesped",
                principalTable: "Huesped",
                principalColumn: "Id_Huesped",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
