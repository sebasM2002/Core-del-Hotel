using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Servicios",
                columns: table => new
                {
                    Id_servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id_servicio);
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
                name: "Empleados",
                columns: table => new
                {
                    Id_Empleados = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Id_Pais = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Correo_electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id_Empleados);
                    table.ForeignKey(
                        name: "FK_Empleados_AspNetUsers_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Paises_Id_Pais",
                        column: x => x.Id_Pais,
                        principalTable: "Paises",
                        principalColumn: "Id_Pais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Huesped",
                columns: table => new
                {
                    Id_Huesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Appelidos = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Id_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Pais = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huesped", x => x.Id_Huesped);
                    table.ForeignKey(
                        name: "FK_Huesped_AspNetUsers_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Huesped_Paises_Id_Pais",
                        column: x => x.Id_Pais,
                        principalTable: "Paises",
                        principalColumn: "Id_Pais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    Id_Habitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_TipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Id_Habitacion);
                    table.ForeignKey(
                        name: "FK_Habitaciones_TipoHabitacion_Id_TipoHabitacion",
                        column: x => x.Id_TipoHabitacion,
                        principalTable: "TipoHabitacion",
                        principalColumn: "Id_TipoHabitacion",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Tarjetas",
                columns: table => new
                {
                    Id_tarjeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_huesped = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cvv = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Nombre_titular = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id_tarjeta);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Huesped_Id_huesped",
                        column: x => x.Id_huesped,
                        principalTable: "Huesped",
                        principalColumn: "Id_Huesped",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    Id_Reservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Huesped = table.Column<int>(type: "int", nullable: false),
                    Id_Habitacion = table.Column<int>(type: "int", nullable: false),
                    Fecha_Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.Id_Reservacion);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Habitaciones_Id_Habitacion",
                        column: x => x.Id_Habitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Huesped_Id_Huesped",
                        column: x => x.Id_Huesped,
                        principalTable: "Huesped",
                        principalColumn: "Id_Huesped",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura_Reservacion",
                columns: table => new
                {
                    Id_Transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Reservacion = table.Column<int>(type: "int", nullable: false),
                    Id_TipoTransaccion = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_Empleados_Id_Pais",
                table: "Empleados",
                column: "Id_Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id_Usuario",
                table: "Empleados",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Reservacion_Id_Reservacion",
                table: "Factura_Reservacion",
                column: "Id_Reservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Reservacion_Id_TipoTransaccion",
                table: "Factura_Reservacion",
                column: "Id_TipoTransaccion");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Id_TipoHabitacion",
                table: "Habitaciones",
                column: "Id_TipoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Id_Pais",
                table: "Huesped",
                column: "Id_Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Huesped_Id_Usuario",
                table: "Huesped",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_Id_Habitacion",
                table: "Reservaciones",
                column: "Id_Habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_Id_Huesped",
                table: "Reservaciones",
                column: "Id_Huesped");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Huesped_Id_Huesped",
                table: "Servicios_Huesped",
                column: "Id_Huesped");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_Id_huesped",
                table: "Tarjetas",
                column: "Id_huesped");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Factura_Reservacion");

            migrationBuilder.DropTable(
                name: "Servicios_Huesped");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "TipoTransaccion");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Huesped");

            migrationBuilder.DropTable(
                name: "TipoHabitacion");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
