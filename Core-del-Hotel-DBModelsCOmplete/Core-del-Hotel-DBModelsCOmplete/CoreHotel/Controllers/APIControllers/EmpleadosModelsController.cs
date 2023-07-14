using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;
using CoreHotel.DTO;
using Microsoft.AspNetCore.Identity;

namespace CoreHotel.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmpleadosModelsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/EmpleadosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadosModel>>> GetEmpleados()
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            return await _context.Empleados.Where(x => x.Is_deleted != true).ToListAsync();
        }

        // GET: api/EmpleadosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadosModel>> GetEmpleadosModel(int id)
        {
          if (_context.Empleados == null)
          {
              return NotFound();
          }
            var empleadosModel = await _context.Empleados.FindAsync(id);

            if (empleadosModel == null)
            {
                return NotFound();
            }

            return empleadosModel;
        }

        // PUT: api/EmpleadosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleadosModel(int id, EmpleadosModel empleadosModel)
        {
            if (id != empleadosModel.Id_Empleados)
            {
                return BadRequest();
            }

            _context.Entry(empleadosModel).State = EntityState.Modified;

            try
            {
                empleadosModel.Updated_at = DateTime.Now.ToString();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosModelExists(id))
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

        // POST: api/EmpleadosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HuespedModel>> PostHuespedModel(RegistrarEmpleadoDTO empleadosModel)
        {
            var user = new IdentityUser { UserName = empleadosModel.email, Email = empleadosModel.email };
            var result = await _userManager.CreateAsync(user, empleadosModel.password);

            if (result.Succeeded)
            {
                if (_context.Huesped == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Huesped'  is null.");
                }
                EmpleadosModel empleado = new EmpleadosModel();
                empleado.Nombre = empleadosModel.Nombre;
                empleado.Telefono = empleadosModel.Telefono;
                empleado.Direccion = empleadosModel.Direccion;
                empleado.Sueldo = empleadosModel.Sueldo;
                empleado.Created_at = DateTime.Now.ToString();
                empleado.Id_Usuario = user.Id;
                empleado.Is_deleted = false;
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();
                return Ok (empleadosModel);
            }

            else
            {
                return BadRequest("Username or password invalid");
            }
        }

        // DELETE: api/EmpleadosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleadosModel(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleadosModel = await _context.Empleados.FindAsync(id);
            if (empleadosModel == null)
            {
                return NotFound();
            }

            empleadosModel.Is_deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadosModelExists(int id)
        {
            return (_context.Empleados?.Any(e => e.Id_Empleados == id)).GetValueOrDefault();
        }
    }
}
