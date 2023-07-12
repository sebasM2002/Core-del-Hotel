using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;

namespace CoreHotel.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaReservacionModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturaReservacionModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FacturaReservacionModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaReservacionModel>>> GetFactura_Reservacion()
        {
          if (_context.Factura_Reservacion == null)
          {
              return NotFound();
          }
            return await _context.Factura_Reservacion.ToListAsync();
        }

        // GET: api/FacturaReservacionModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaReservacionModel>> GetFacturaReservacionModel(int id)
        {
          if (_context.Factura_Reservacion == null)
          {
              return NotFound();
          }
            var facturaReservacionModel = await _context.Factura_Reservacion.FindAsync(id);

            if (facturaReservacionModel == null)
            {
                return NotFound();
            }

            return facturaReservacionModel;
        }

        // PUT: api/FacturaReservacionModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaReservacionModel(int id, FacturaReservacionModel facturaReservacionModel)
        {
            if (id != facturaReservacionModel.Id_Transaccion)
            {
                return BadRequest();
            }

            _context.Entry(facturaReservacionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaReservacionModelExists(id))
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

        // POST: api/FacturaReservacionModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaReservacionModel>> PostFacturaReservacionModel(FacturaReservacionModel facturaReservacionModel)
        {
          if (_context.Factura_Reservacion == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Factura_Reservacion'  is null.");
          }
            _context.Factura_Reservacion.Add(facturaReservacionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaReservacionModel", new { id = facturaReservacionModel.Id_Transaccion }, facturaReservacionModel);
        }

        // DELETE: api/FacturaReservacionModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaReservacionModel(int id)
        {
            if (_context.Factura_Reservacion == null)
            {
                return NotFound();
            }
            var facturaReservacionModel = await _context.Factura_Reservacion.FindAsync(id);
            if (facturaReservacionModel == null)
            {
                return NotFound();
            }

            _context.Factura_Reservacion.Remove(facturaReservacionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaReservacionModelExists(int id)
        {
            return (_context.Factura_Reservacion?.Any(e => e.Id_Transaccion == id)).GetValueOrDefault();
        }
    }
}
