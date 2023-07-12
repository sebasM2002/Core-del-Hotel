using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;

namespace CoreHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoosModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoosModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmpleadoosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoosModel>>> GetEmpleados()
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/EmpleadoosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoosModel>> GetEmpleadoosModel(int id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var empleadoosModel = await _context.Empleados.FindAsync(id);

            if (empleadoosModel == null)
            {
                return NotFound();
            }

            return empleadoosModel;
        }

        // PUT: api/EmpleadoosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleadoosModel(int id, EmpleadoosModel empleadoosModel)
        {
            if (id != empleadoosModel.Id_Empleados)
            {
                return BadRequest();
            }

            _context.Entry(empleadoosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoosModelExists(id))
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

        // POST: api/EmpleadoosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpleadoosModel>> PostEmpleadoosModel(EmpleadoosModel empleadoosModel)
        {
          if (_context.Empleados == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Empleados'  is null.");
          }
            _context.Empleados.Add(empleadoosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleadoosModel", new { id = empleadoosModel.Id_Empleados }, empleadoosModel);
        }

        // DELETE: api/EmpleadoosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleadoosModel(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleadoosModel = await _context.Empleados.FindAsync(id);
            if (empleadoosModel == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleadoosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoosModelExists(int id)
        {
            return (_context.Empleados?.Any(e => e.Id_Empleados == id)).GetValueOrDefault();
        }
    }
}
