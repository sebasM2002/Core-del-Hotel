using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;
using CoreHotel.DTO;
using Microsoft.AspNetCore.Identity;

namespace CoreHotel.Controllers.MVCControllers
{
    public class HuespedModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HuespedModelsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: HuespedModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Huesped.Where(x => x.Is_deleted != true).ToListAsync());
        }

        // GET: HuespedModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Huesped == null)
            {
                return NotFound();
            }

            var huespedModel = await _context.Huesped
                .FirstOrDefaultAsync(m => m.Id_Huesped == id);
            if (huespedModel == null)
            {
                return NotFound();
            }

            return View(huespedModel);
        }

        // GET: HuespedModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HuespedModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrarHuespedDTO huespedModel)
        {
            if (huespedModel.email == null || huespedModel.password == null)
            {
                if (ModelState.IsValid)
                {
                    HuespedModel huesped = new HuespedModel();
                    huesped.Nombre = huespedModel.Nombre;
                    huesped.Apellidos = huespedModel.Apellidos;
                    huesped.Telefono = huespedModel.Telefono;
                    huesped.Created_at = DateTime.Now.ToString();
                    huesped.Is_deleted = false;
                    _context.Add(huesped);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(huespedModel);
            }
            else
            {
                var user = new IdentityUser { UserName = huespedModel.email, Email = huespedModel.email };
                var result = await _userManager.CreateAsync(user, huespedModel.password);

                if (result.Succeeded)
                {
                    if (ModelState.IsValid)
                    {
                        HuespedModel huesped = new HuespedModel();
                        huesped.Nombre = huespedModel.Nombre;
                        huesped.Apellidos = huespedModel.Apellidos;
                        huesped.Telefono = huespedModel.Telefono;
                        huesped.Created_at = DateTime.Now.ToString();
                        huesped.Id_Usuario = user.Id;
                        huesped.Is_deleted= false;
                        _context.Huesped.Add(huesped);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(huespedModel);
                }
                else
                {
                    return BadRequest("Username or password invalid");
                }
            }
        }

        // GET: HuespedModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Huesped == null)
            {
                return NotFound();
            }

            var huespedModel = await _context.Huesped.FindAsync(id);
            if (huespedModel == null)
            {
                return NotFound();
            }
            return View(huespedModel);
        }

        // POST: HuespedModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Huesped,Nombre,Apellidos,Telefono,Id_Usuario,Is_deleted,Created_at,Updated_at")] HuespedModel huespedModel)
        {
            if (id != huespedModel.Id_Huesped)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    huespedModel.Updated_at = DateTime.Now.ToString();
                    _context.Update(huespedModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuespedModelExists(huespedModel.Id_Huesped))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(huespedModel);
        }

        // GET: HuespedModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Huesped == null)
            {
                return NotFound();
            }

            var huespedModel = await _context.Huesped
                .FirstOrDefaultAsync(m => m.Id_Huesped == id);
            if (huespedModel == null)
            {
                return NotFound();
            }

            return View(huespedModel);
        }

        // POST: HuespedModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Huesped == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Huesped'  is null.");
            }
            var huespedModel = await _context.Huesped.FindAsync(id);
            if (huespedModel != null)
            {
                huespedModel.Is_deleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuespedModelExists(int id)
        {
          return (_context.Huesped?.Any(e => e.Id_Huesped == id)).GetValueOrDefault();
        }
    }
}
