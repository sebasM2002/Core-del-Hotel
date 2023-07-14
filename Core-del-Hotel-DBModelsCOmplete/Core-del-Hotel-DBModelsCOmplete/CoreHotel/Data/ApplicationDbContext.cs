using CoreHotel.Areas.Identity.Pages.Account;
using CoreHotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using CoreHotel.DTO;

namespace CoreHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServicioFacturaModel>()
                        .HasKey(c => new { c.Id_servicio, c.Id_Factura});
        }

        public DbSet <EmpleadosModel> Empleados { get; set; }
        public DbSet<FacturaModel> Facturas { get; set; }
        public DbSet<ServicioFacturaModel> ServiciosFactura { get; set; }
        public DbSet<HabitacionesModel> Habitaciones { get; set; }
        public DbSet<HuespedModel> Huesped { get; set; }
        public DbSet<ReservacionesModel> Reservaciones { get; set; }
        public DbSet<ServicioModel> Servicios { get; set; }
        public DbSet<TarjetasCreditoModel> Tarjetas { get; set; } 
        public DbSet<CuentasPorCobrarModel> CuentasPorCobrar { get; set; }
    }
}