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
    public class FacturaModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FacturaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaModel>>> GetFacturas()
        {
          if (_context.Facturas == null)
          {
              return NotFound();
          }
            return await _context.Facturas.Where(x => x.is_deleted != true).ToListAsync();
        }

        // GET: api/FacturaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaModel>> GetFacturaModel(int id)
        {
          if (_context.Facturas == null)
          {
              return NotFound();
          }
            var facturaModel = await _context.Facturas.FindAsync(id);

            if (facturaModel == null)
            {
                return NotFound();
            }

            return facturaModel;
        }

        // PUT: api/FacturaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaModel(int id, FacturaModel facturaModel)
        {
            if (id != facturaModel.Id_Factura)
            {
                return BadRequest();
            }

            _context.Entry(facturaModel).State = EntityState.Modified;

            try
            {
                facturaModel.updated_at = DateTime.Now.ToString();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaModelExists(id))
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

        // POST: api/FacturaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaModel>> PostFacturaModel(FacturaModel facturaModel)
        {
          if (_context.Facturas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Facturas'  is null.");
          }
            facturaModel.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
            facturaModel.created_at = DateTime.Now.ToString();
            facturaModel.is_deleted = false;
            _context.Facturas.Add(facturaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaModel", new { id = facturaModel.Id_Factura }, facturaModel);
        }

        // DELETE: api/FacturaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaModel(int id, FacturaModel facturaModel)
        {
            if (_context.Facturas == null)
            {
                return NotFound();
            }
            var facturaModelos = await _context.Facturas.FindAsync(id);
            if (facturaModelos == null)
            {
                return NotFound();
            }

            facturaModel.is_deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaModelExists(int id)
        {
            return (_context.Facturas?.Any(e => e.Id_Factura == id)).GetValueOrDefault();
        }
    }
}
