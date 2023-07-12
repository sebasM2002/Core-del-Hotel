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
    public class HuespedModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HuespedModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HuespedModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HuespedModel>>> GetHuesped()
        {
          if (_context.Huesped == null)
          {
              return NotFound();
          }
            return await _context.Huesped.ToListAsync();
        }

        // GET: api/HuespedModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HuespedModel>> GetHuespedModel(int id)
        {
          if (_context.Huesped == null)
          {
              return NotFound();
          }
            var huespedModel = await _context.Huesped.FindAsync(id);

            if (huespedModel == null)
            {
                return NotFound();
            }

            return huespedModel;
        }

        // PUT: api/HuespedModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuespedModel(int id, HuespedModel huespedModel)
        {
            if (id != huespedModel.Id_Huesped)
            {
                return BadRequest();
            }

            _context.Entry(huespedModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HuespedModelExists(id))
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

        // POST: api/HuespedModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HuespedModel>> PostHuespedModel(HuespedModel huespedModel)
        {
          if (_context.Huesped == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Huesped'  is null.");
          }
            _context.Huesped.Add(huespedModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHuespedModel", new { id = huespedModel.Id_Huesped }, huespedModel);
        }

        // DELETE: api/HuespedModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuespedModel(int id)
        {
            if (_context.Huesped == null)
            {
                return NotFound();
            }
            var huespedModel = await _context.Huesped.FindAsync(id);
            if (huespedModel == null)
            {
                return NotFound();
            }

            _context.Huesped.Remove(huespedModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HuespedModelExists(int id)
        {
            return (_context.Huesped?.Any(e => e.Id_Huesped == id)).GetValueOrDefault();
        }
    }
}
