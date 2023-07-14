using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;

namespace CoreHotel.Controllers.MVCControllers
{
    public class HabitacionesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitacionesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HabitacionesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habitaciones.Where(x => x.Is_deleted != true).ToListAsync());
        }

        // GET: HabitacionesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacionesModel = await _context.Habitaciones
                .FirstOrDefaultAsync(m => m.Id_Habitacion == id);
            if (habitacionesModel == null)
            {
                return NotFound();
            }

            return View(habitacionesModel);
        }

        // GET: HabitacionesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HabitacionesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HabitacionesModel habitacionesModel)
        {
            if (ModelState.IsValid)
            {
                habitacionesModel.Is_deleted = false;
                _context.Add(habitacionesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitacionesModel);
        }

        // GET: HabitacionesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacionesModel = await _context.Habitaciones.FindAsync(id);
            if (habitacionesModel == null)
            {
                return NotFound();
            }
            return View(habitacionesModel);
        }

        // POST: HabitacionesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Habitacion,descripcion,Limite,Precio_por_noche,Is_deleted,Created_at,Updated_at")] HabitacionesModel habitacionesModel)
        {
            if (id != habitacionesModel.Id_Habitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    habitacionesModel.Updated_at = DateTime.Now.ToString();
                    _context.Update(habitacionesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionesModelExists(habitacionesModel.Id_Habitacion))
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
            return View(habitacionesModel);
        }

        // GET: HabitacionesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacionesModel = await _context.Habitaciones
                .FirstOrDefaultAsync(m => m.Id_Habitacion == id);
            if (habitacionesModel == null)
            {
                return NotFound();
            }

            return View(habitacionesModel);
        }

        // POST: HabitacionesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habitaciones'  is null.");
            }
            var habitacionesModel = await _context.Habitaciones.FindAsync(id);
            if (habitacionesModel != null)
            {
                habitacionesModel.Is_deleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionesModelExists(int id)
        {
          return (_context.Habitaciones?.Any(e => e.Id_Habitacion == id)).GetValueOrDefault();
        }
    }
}
