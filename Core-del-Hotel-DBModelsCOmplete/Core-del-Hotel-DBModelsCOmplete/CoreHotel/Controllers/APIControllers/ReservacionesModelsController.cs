using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.DTO;
using CoreHotel.Models;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreHotel.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservacionesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservacionesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservacionesModel>>> GetReservaciones()
        {
            if (_context.Reservaciones == null)
            {
                return NotFound();
            }
            return await _context.Reservaciones.Where(x => x.is_Deleted != true).ToListAsync();
        }

        // GET: api/ReservacionesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservacionesModel>> GetReservacionesModel(int id)
        {
            if (_context.Reservaciones == null)
            {
                return NotFound();
            }
            var reservacionesModel = await _context.Reservaciones.FindAsync(id);

            if (reservacionesModel == null)
            {
                return NotFound();
            }

            return reservacionesModel;
        }

        // PUT: api/ReservacionesModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacionesModel(int id, ReservacionesModel reservacionesModel)
        {
            if (id != reservacionesModel.Id_Reservacion)
            {
                return BadRequest();
            }

            _context.Entry(reservacionesModel).State = EntityState.Modified;

            try
            {
                reservacionesModel.Updated_at = DateTime.Now.ToString();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionesModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReservacionesModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservacionesModel>> PostReservacionesModel(ReservacionHabitacionDTO ReservacionDTO, int id_Habitacion)
        {
            if (_context.Reservaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservaciones'  is null.");
            }

            var habitaciones = _context.Habitaciones.Where(x => x.descripcion == ReservacionDTO.descripcion && x.Limite >= ReservacionDTO.Cantidad).ToList();
            var reservaciones = _context.Reservaciones.Where(y => y.is_Deleted != true).ToList();
            reservaciones = reservaciones.Where(r => habitaciones.Any(h => h.Id_Habitacion == r.Id_Habitacion)).ToList();

            var habitacionesSinReservaciones = habitaciones.Where(h => !reservaciones.Any(r => r.Id_Habitacion == h.Id_Habitacion)).ToList();


            if (reservaciones.Count == 0 || habitacionesSinReservaciones.Count > 0)
            {
                ReservacionesModel reservation = new ReservacionesModel();
                reservation.Fecha_Entrada = ReservacionDTO.Fecha_Entrada;
                reservation.Fecha_Salida = ReservacionDTO.Fecha_Salida;
                reservation.Cantidad = ReservacionDTO.Cantidad;
                reservation.is_Deleted = false;
                reservation.Created_at = DateTime.Now.ToString();
                reservation.Id_Huesped = ReservacionDTO.Id_Huesped;
                reservation.check_In = false;
                reservation.Id_Habitacion = habitacionesSinReservaciones[0].Id_Habitacion;
                _context.Reservaciones.Add(reservation);
                await _context.SaveChangesAsync();

                FacturaModel factura = new FacturaModel();
                factura.Id_Reservacion = reservation.Id_Reservacion;
                var monto = await _context.Habitaciones.FirstOrDefaultAsync(x => x.Id_Habitacion == reservation.Id_Habitacion);
                TimeSpan difference = DateTime.Parse(reservation.Fecha_Salida) - DateTime.Parse(reservation.Fecha_Entrada);
                double rango = difference.TotalDays;
                factura.Monto_total = monto.Precio_por_noche * Convert.ToDecimal(rango);
                factura.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                factura.is_deleted = false;
                factura.created_at = DateTime.Now.ToString();
                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();
                return Ok();
            }
            foreach (var resvp in reservaciones)
            {

                if (DateTime.Parse(ReservacionDTO.Fecha_Entrada) >= DateTime.Parse(resvp.Fecha_Entrada) && DateTime.Parse(ReservacionDTO.Fecha_Entrada) <= DateTime.Parse(resvp.Fecha_Salida) ||
                DateTime.Parse(ReservacionDTO.Fecha_Salida) >= DateTime.Parse(resvp.Fecha_Entrada) && DateTime.Parse(ReservacionDTO.Fecha_Salida) <= DateTime.Parse(resvp.Fecha_Salida))
                {
                    NoContent();
                }
                else
                {
                    ReservacionesModel reservation = new ReservacionesModel();
                    reservation.Fecha_Entrada = ReservacionDTO.Fecha_Entrada;
                    reservation.Fecha_Salida = ReservacionDTO.Fecha_Salida;
                    reservation.Cantidad = ReservacionDTO.Cantidad;
                    reservation.is_Deleted = false;
                    reservation.check_In = false;
                    reservation.Created_at = DateTime.Now.ToString();
                    reservation.Id_Huesped = ReservacionDTO.Id_Huesped;
                    reservation.Id_Habitacion = resvp.Id_Habitacion;
                    _context.Reservaciones.Add(reservation);
                    await _context.SaveChangesAsync();

                    FacturaModel factura = new FacturaModel();
                    factura.Id_Reservacion = reservation.Id_Reservacion;
                    var monto = await _context.Habitaciones.FirstOrDefaultAsync(x => x.Id_Habitacion == reservation.Id_Habitacion);
                    TimeSpan difference = DateTime.Parse(reservation.Fecha_Salida) - DateTime.Parse(reservation.Fecha_Entrada);
                    double rango = difference.TotalDays;
                    factura.Monto_total = monto.Precio_por_noche * Convert.ToDecimal(rango);
                    factura.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    factura.is_deleted = false;
                    factura.created_at = DateTime.Now.ToString();
                    _context.Facturas.Add(factura);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

            }

            return NoContent();

           
        }

// DELETE: api/ReservacionesModels/5
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteReservacionesModel(int id)
{
    if (_context.Reservaciones == null)
    {
        return NotFound();
    }
    var reservacionesModel = await _context.Reservaciones.FindAsync(id);
    if (reservacionesModel == null)
    {
        return NotFound();
    }

    reservacionesModel.is_Deleted = true; 
    await _context.SaveChangesAsync();

    return NoContent();
}

private bool ReservacionesModelExists(int id)
{
    return (_context.Reservaciones?.Any(e => e.Id_Reservacion == id)).GetValueOrDefault();
}
    }
}
