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
    public class HabitacionesModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HabitacionesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HabitacionesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitacionesModel>>> GetHabitaciones()
        {
          if (_context.Habitaciones == null)
          {
              return NotFound();
          }
            return await _context.Habitaciones.Where(x => x.Is_deleted != true).ToListAsync();
        }

        // GET: api/HabitacionesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitacionesModel>> GetHabitacionesModel(int id)
        {
          if (_context.Habitaciones == null)
          {
              return NotFound();
          }
            var habitacionesModel = await _context.Habitaciones.FindAsync(id);

            if (habitacionesModel == null)
            {
                return NotFound();
            }

            return habitacionesModel;
        }

        // PUT: api/HabitacionesModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitacionesModel(int id, HabitacionesModel habitacionesModel)
        {
            if (id != habitacionesModel.Id_Habitacion)
            {
                return BadRequest();
            }

            _context.Entry(habitacionesModel).State = EntityState.Modified;

            try
            {
                habitacionesModel.Updated_at = DateTime.Now.ToString();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionesModelExists(id))
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

        // POST: api/HabitacionesModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HabitacionesModel>> PostHabitacionesModel(HabitacionesModel habitacionesModel)
        {
          if (_context.Habitaciones == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Habitaciones'  is null.");
          }
            habitacionesModel.Created_at = DateTime.Now.ToString();
            habitacionesModel.Is_deleted = false;
            _context.Habitaciones.Add(habitacionesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitacionesModel", new { id = habitacionesModel.Id_Habitacion }, habitacionesModel);
        }

        // DELETE: api/HabitacionesModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacionesModel(int id)
        {
            if (_context.Habitaciones == null)
            {
                return NotFound();
            }
            var habitacionesModel = await _context.Habitaciones.FindAsync(id);
            if (habitacionesModel == null)
            {
                return NotFound();
            }

            habitacionesModel.Is_deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitacionesModelExists(int id)
        {
            return (_context.Habitaciones?.Any(e => e.Id_Habitacion == id)).GetValueOrDefault();
        }
    }
}
