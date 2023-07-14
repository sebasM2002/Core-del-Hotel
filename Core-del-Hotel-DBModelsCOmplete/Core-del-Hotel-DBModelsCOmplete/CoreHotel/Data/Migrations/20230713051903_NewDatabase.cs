using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Paises_Id_Pais",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_TipoHabitacion_Id_TipoHabitacion",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Huesped_Paises_Id_Pais",
                table: "Huesped");

            migrationBuilder.DropTable(
                name: "Factura_Reservacion");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Servicios_Huesped");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "TipoTransaccion");

            migrationBuilder.DropIndex(
                name: "IX_Huesped_Id_Pais",
                table: "Huesped");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_Id_TipoHabitacion",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_Id_Pais",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Id_Pais",
                table: "Huesped");

            migrationBuilder.DropColumn(
                name: "Id_Pais",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Servicios",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Habitaciones",
                newName: "Precio_por_noche");

            migrationBuilder.RenameColumn(
                name: "Id_TipoHabitacion",
                table: "Habitaciones",
                newName: "Limite");

            migrationBuilder.AlterColumn<string>(
                name: "numero",
                table: "Tarjetas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "Tarjetas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Tarjetas",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FechaVencimiento",
                table: "Tarjetas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Created_at",
                table: "Tarjetas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Servicios",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Created_at",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha_Salida",
                table: "Reservaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha_Entrada",
                table: "Reservaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "is_Deleted",
                table: "Reservaciones",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "Huesped",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Huesped",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Created_at",
                table: "Huesped",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Huesped",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "Habitaciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Habitaciones",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Created_at",
                table: "Habitaciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Empleados",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Created_at",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id_Factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Reservacion = table.Column<int>(type: "int", nullable: false),
                    Monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metodo_de_pago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_at = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id_Factura);
                    table.ForeignKey(
                        name: "FK_Facturas_Reservaciones_Id_Reservacion",
                        column: x => x.Id_Reservacion,
                        principalTable: "Reservaciones",
                        principalColumn: "Id_Reservacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosFactura",
                columns: table => new
                {
                    Id_servicio = table.Column<int>(type: "int", nullable: false),
                    Id_Huesped = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosFactura", x => new { x.Id_servicio, x.Id_Huesped });
                    table.ForeignKey(
                        name: "FK_ServiciosFactura_Huesped_Id_Huesped",
                        column: x => x.Id_Huesped,
                        principalTable: "Huesped",
                        principalColumn: "Id_Huesped",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosFactura_Servicios_Id_servicio",
                        column: x => x.Id_servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id_servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentasPorCobrar",
                columns: table => new
                {
                    id_cuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_factura = table.Column<int>(type: "int", nullable: false),
                    Fecha_vencimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_at = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasPorCobrar", x => x.id_cuenta);
                    table.ForeignKey(
                        name: "FK_CuentasPorCobrar_Facturas_id_factura",
                        column: x => x.id_factura,
                        principalTable: "Facturas",
                        principalColumn: "Id_Factura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasPorCobrar_id_factura",
                table: "CuentasPorCobrar",
                column: "id_factura");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Id_Reservacion",
                table: "Facturas",
                column: "Id_Reservacion");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosFactura_Id_Huesped",
                table: "ServiciosFactura",
                column: "Id_Huesped");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasPorCobrar");

            migrationBuilder.DropTable(
                name: "ServiciosFactura");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "is_Deleted",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Huesped");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Servicios",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Precio_por_noche",
                table: "Habitaciones",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "Limite",
                table: "Habitaciones",
                newName: "Id_TipoHabitacion");

            migrationBuilder.AlterColumn<int>(
                name: "numero",
                table: "Tarjetas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Tarjetas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Tarjetas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Tarjetas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tarjetas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Servicios",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Salida",
                table: "Reservaciones",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Entrada",
                table: "Reservaciones",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Huesped",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Huesped",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Huesped",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Id_Pais",
                table: "Huesped",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Habitaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Habitaciones",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Habitaciones",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_at",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Is_deleted",
                table: "Empleados",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Id_Pais",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id_Pais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id_Pais);
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Huesped",
                columns: table => new
                {
                    Id_servicio = table.Column<int>(type: "int", nullable: false),
                    Id_Huesped = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios_Huesped", x => new { x.Id_servicio, x.Id_Huesped });
                    table.ForeignKey(
                        name: "FK_Servicios_Huesped_Huesped_Id_Huesped",
                        column: x => x.Id_Huesped,
                        principalTable: "Huesped",
                        principalColumn: "Id_Huesped",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Huesped_Servicios_Id_servicio",
                        column: x => x.Id_servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id_servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitacion",
                columns: table => new
                {
                    Id_TipoHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitacion", x => x.Id_TipoHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransaccion",
                columns: table => new
                {
                    Id_TipoTransaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransaccion", x => x.Id_TipoTransaccion);
                });

            migrationBuilder.CreateTable(
                name: "Factura_Reservacion",
                columns: table => new
                {
                    Id_Transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Reservacion = table.Column<int>(type: "int", nullable: false),
                    Id_TipoTransaccion = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura_Reservacion", x => x.Id_Transaccion);
                    table.ForeignKey(
                        name: "FK_Factura_Reservacion_Reservaciones_Id_Reservacion",
                        column: x => x.Id_Reservacion,
                        principalTable: "Reservaciones",
                        principalColumn: "Id_Reservacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Reservacion_TipoTransaccion_Id_TipoTransaccion",
                        column: x => x.Id_TipoTransaccion,
                        principalTable: "TipoTransaccion",
                        principalColumn: "Id_TipoTransaccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Id_Pais",
                table: "Huesped",
                column: "Id_Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Id_TipoHabitacion",
                table: "Habitaciones",
                column: "Id_TipoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id_Pais",
                table: "Empleados",
                column: "Id_Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Reservacion_Id_Reservacion",
                table: "Factura_Reservacion",
                column: "Id_Reservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Reservacion_Id_TipoTransaccion",
                table: "Factura_Reservacion",
                column: "Id_TipoTransaccion");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Huesped_Id_Huesped",
                table: "Servicios_Huesped",
                column: "Id_Huesped");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Paises_Id_Pais",
                table: "Empleados",
                column: "Id_Pais",
                principalTable: "Paises",
                principalColumn: "Id_Pais",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_TipoHabitacion_Id_TipoHabitacion",
                table: "Habitaciones",
                column: "Id_TipoHabitacion",
                principalTable: "TipoHabitacion",
                principalColumn: "Id_TipoHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Huesped_Paises_Id_Pais",
                table: "Huesped",
                column: "Id_Pais",
                principalTable: "Paises",
                principalColumn: "Id_Pais",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
