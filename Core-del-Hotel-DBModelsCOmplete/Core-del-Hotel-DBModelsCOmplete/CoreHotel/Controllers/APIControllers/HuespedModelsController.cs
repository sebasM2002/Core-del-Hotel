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
    public class HuespedModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HuespedModelsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/HuespedModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HuespedModel>>> GetHuesped()
        {
          if (_context.Huesped == null)
          {
              return NotFound();
          }
            return await _context.Huesped.Where(x => x.Is_deleted != true).ToListAsync();
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
                huespedModel.Updated_at = DateTime.Now.ToString();
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
        public async Task<ActionResult<HuespedModel>> PostHuespedModel(RegistrarHuespedDTO huespedModel)
        {
            var user = new IdentityUser { UserName = huespedModel.email, Email = huespedModel.email };
            var result = await _userManager.CreateAsync(user, huespedModel.password);
            if (result.Succeeded)
            {
                if (_context.Huesped == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Huesped'  is null.");
                }
                HuespedModel huesped = new HuespedModel();
                huesped.Nombre = huespedModel.Nombre;
                huesped.Apellidos = huespedModel.Apellidos;
                huesped.Telefono = huespedModel.Telefono;
                huesped.Created_at = DateTime.Now.ToString();
                huesped.Id_Usuario = user.Id;
                huesped.Is_deleted = false;
                _context.Huesped.Add(huesped);
                await _context.SaveChangesAsync();
                return Ok(huesped);
            }

            else
            {
                return BadRequest("Username or password invalid");
            }
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

            huespedModel.Is_deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HuespedModelExists(int id)
        {
            return (_context.Huesped?.Any(e => e.Id_Huesped == id)).GetValueOrDefault();
        }
    }
}
