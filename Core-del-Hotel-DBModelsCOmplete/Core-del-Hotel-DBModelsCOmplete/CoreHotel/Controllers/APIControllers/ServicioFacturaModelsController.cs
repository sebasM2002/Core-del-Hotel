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
    public class ServicioFacturaModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicioFacturaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServicioFacturaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioFacturaModel>>> GetServiciosFactura()
        {
          if (_context.ServiciosFactura == null)
          {
              return NotFound();
          }
            return await _context.ServiciosFactura.ToListAsync();
        }

        // GET: api/ServicioFacturaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioFacturaModel>> GetServicioFacturaModel(int id)
        {
          if (_context.ServiciosFactura == null)
          {
              return NotFound();
          }
            var servicioFacturaModel = await _context.ServiciosFactura.FindAsync(id);

            if (servicioFacturaModel == null)
            {
                return NotFound();
            }

            return servicioFacturaModel;
        }

        // PUT: api/ServicioFacturaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioFacturaModel(int id, ServicioFacturaModel servicioFacturaModel)
        {
            if (id != servicioFacturaModel.Id_servicio)
            {
                return BadRequest();
            }

            _context.Entry(servicioFacturaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioFacturaModelExists(id))
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

        // POST: api/ServicioFacturaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicioFacturaModel>> PostServicioFacturaModel(ServicioFacturaModel servicioFacturaModel)
        {
          if (_context.ServiciosFactura == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ServiciosFactura'  is null.");
          }

            var precioServicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Id_servicio == servicioFacturaModel.Id_servicio);
            var Factura = await _context.Facturas.FirstOrDefaultAsync(x => x.Id_Factura == servicioFacturaModel.Id_Factura);

            decimal precio = precioServicio.Precio;
            Factura.Monto_total += precio;
            Factura.updated_at = DateTime.Now.ToString();

            _context.ServiciosFactura.Add(servicioFacturaModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicioFacturaModelExists(servicioFacturaModel.Id_servicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServicioFacturaModel", new { id = servicioFacturaModel.Id_servicio }, servicioFacturaModel);
        }
        private bool ServicioFacturaModelExists(int id)
        {
            return (_context.ServiciosFactura?.Any(e => e.Id_servicio == id)).GetValueOrDefault();
        }
    }
}
