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
    public class ServicioModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicioModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicios.Where(x => x.Is_deleted != true).ToListAsync());
        }

        // GET: ServicioModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicioModel = await _context.Servicios
                .FirstOrDefaultAsync(m => m.Id_servicio == id);
            if (servicioModel == null)
            {
                return NotFound();
            }

            return View(servicioModel);
        }

        // GET: ServicioModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_servicio,Descripcion,Precio,Is_deleted,Created_at,Updated_at")] ServicioModel servicioModel)
        {
            if (ModelState.IsValid)
            {
                servicioModel.Is_deleted = false;
                _context.Add(servicioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioModel);
        }

        // GET: ServicioModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicioModel = await _context.Servicios.FindAsync(id);
            if (servicioModel == null)
            {
                return NotFound();
            }
            return View(servicioModel);
        }

        // POST: ServicioModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_servicio,Descripcion,Precio,Is_deleted,Created_at,Updated_at")] ServicioModel servicioModel)
        {
            if (id != servicioModel.Id_servicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    servicioModel.Updated_at = DateTime.Now.ToString();
                    _context.Update(servicioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioModelExists(servicioModel.Id_servicio))
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
            return View(servicioModel);
        }

        // GET: ServicioModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicioModel = await _context.Servicios
                .FirstOrDefaultAsync(m => m.Id_servicio == id);
            if (servicioModel == null)
            {
                return NotFound();
            }

            return View(servicioModel);
        }

        // POST: ServicioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Servicios'  is null.");
            }
            var servicioModel = await _context.Servicios.FindAsync(id);
            if (servicioModel != null)
            {
                servicioModel.Is_deleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioModelExists(int id)
        {
          return (_context.Servicios?.Any(e => e.Id_servicio == id)).GetValueOrDefault();
        }
    }
}
