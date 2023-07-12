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
    public class ServicioModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicioModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServicioModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioModel>>> GetServicios()
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            return await _context.Servicios.ToListAsync();
        }

        // GET: api/ServicioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioModel>> GetServicioModel(int id)
        {
          if (_context.Servicios == null)
          {
              return NotFound();
          }
            var servicioModel = await _context.Servicios.FindAsync(id);

            if (servicioModel == null)
            {
                return NotFound();
            }

            return servicioModel;
        }

        // PUT: api/ServicioModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioModel(int id, ServicioModel servicioModel)
        {
            if (id != servicioModel.Id_servicio)
            {
                return BadRequest();
            }

            _context.Entry(servicioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioModelExists(id))
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

        // POST: api/ServicioModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicioModel>> PostServicioModel(ServicioModel servicioModel)
        {
          if (_context.Servicios == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Servicios'  is null.");
          }
            _context.Servicios.Add(servicioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioModel", new { id = servicioModel.Id_servicio }, servicioModel);
        }

        // DELETE: api/ServicioModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicioModel(int id)
        {
            if (_context.Servicios == null)
            {
                return NotFound();
            }
            var servicioModel = await _context.Servicios.FindAsync(id);
            if (servicioModel == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioModelExists(int id)
        {
            return (_context.Servicios?.Any(e => e.Id_servicio == id)).GetValueOrDefault();
        }
    }
}
