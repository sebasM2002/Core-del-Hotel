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
    public class PaisModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaisModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaisModels
        public async Task<IActionResult> Index()
        {
              return _context.Paises != null ? 
                          View(await _context.Paises.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Paises'  is null.");
        }

        // GET: PaisModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paisModel = await _context.Paises
                .FirstOrDefaultAsync(m => m.Id_Pais == id);
            if (paisModel == null)
            {
                return NotFound();
            }

            return View(paisModel);
        }

        // GET: PaisModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaisModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Pais,Name")] PaisModel paisModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paisModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paisModel);
        }

        // GET: PaisModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paisModel = await _context.Paises.FindAsync(id);
            if (paisModel == null)
            {
                return NotFound();
            }
            return View(paisModel);
        }

        // POST: PaisModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Pais,Name")] PaisModel paisModel)
        {
            if (id != paisModel.Id_Pais)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paisModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisModelExists(paisModel.Id_Pais))
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
            return View(paisModel);
        }

        // GET: PaisModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paisModel = await _context.Paises
                .FirstOrDefaultAsync(m => m.Id_Pais == id);
            if (paisModel == null)
            {
                return NotFound();
            }

            return View(paisModel);
        }

        // POST: PaisModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paises == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Paises'  is null.");
            }
            var paisModel = await _context.Paises.FindAsync(id);
            if (paisModel != null)
            {
                _context.Paises.Remove(paisModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisModelExists(int id)
        {
          return (_context.Paises?.Any(e => e.Id_Pais == id)).GetValueOrDefault();
        }
    }
}
