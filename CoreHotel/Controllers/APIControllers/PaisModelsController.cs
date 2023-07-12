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
    public class PaisModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaisModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaisModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisModel>>> GetPaises()
        {
          if (_context.Paises == null)
          {
              return NotFound();
          }
            return await _context.Paises.ToListAsync();
        }

        // GET: api/PaisModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisModel>> GetPaisModel(int id)
        {
          if (_context.Paises == null)
          {
              return NotFound();
          }
            var paisModel = await _context.Paises.FindAsync(id);

            if (paisModel == null)
            {
                return NotFound();
            }

            return paisModel;
        }

        // PUT: api/PaisModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaisModel(int id, PaisModel paisModel)
        {
            if (id != paisModel.Id_Pais)
            {
                return BadRequest();
            }

            _context.Entry(paisModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisModelExists(id))
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

        // POST: api/PaisModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaisModel>> PostPaisModel(PaisModel paisModel)
        {
          if (_context.Paises == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Paises'  is null.");
          }
            _context.Paises.Add(paisModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaisModel", new { id = paisModel.Id_Pais }, paisModel);
        }

        // DELETE: api/PaisModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaisModel(int id)
        {
            if (_context.Paises == null)
            {
                return NotFound();
            }
            var paisModel = await _context.Paises.FindAsync(id);
            if (paisModel == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paisModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisModelExists(int id)
        {
            return (_context.Paises?.Any(e => e.Id_Pais == id)).GetValueOrDefault();
        }
    }
}
