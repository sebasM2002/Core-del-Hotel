using CoreHotel.Areas.Identity.Pages.Account;
using CoreHotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

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

            modelBuilder.Entity<ServicioHuespedModel>()
                        .HasKey(c => new { c.Id_servicio, c.Id_Huesped });
        }

        public DbSet <EmpleadoosModel> Empleados { get; set; }
        public DbSet <PaisModel> Paises { get; set; }
        public DbSet<FacturaReservacionModel> Factura_Reservacion { get; set; }
        public DbSet<ServicioHuespedModel> Servicios_Huesped { get; set; }
        public DbSet<HabitacionesModel> Habitaciones { get; set; }
        public DbSet<HuespedModel> Huesped { get; set; }
        public DbSet<ReservacionesModel> Reservaciones { get; set; }
        public DbSet<ServicioModel> Servicios { get; set; }
        public DbSet<TarjetasCreditoModel> Tarjetas { get; set; } 
        public DbSet<TipoHabitacionModel> TipoHabitacion { get; set; }
        public DbSet<TipoTransModel> TipoTransaccion { get; set; }
    }
}