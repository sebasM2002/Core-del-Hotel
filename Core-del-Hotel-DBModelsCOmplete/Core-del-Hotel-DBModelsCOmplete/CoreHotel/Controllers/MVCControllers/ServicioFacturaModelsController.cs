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
    public class ServicioFacturaModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioFacturaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicioFacturaModels
        public async Task<IActionResult> Index()
        {
              return _context.ServiciosFactura != null ? 
                          View(await _context.ServiciosFactura.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ServiciosFactura'  is null.");
        }

        // GET: ServicioFacturaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiciosFactura == null)
            {
                return NotFound();
            }

            var servicioFacturaModel = await _context.ServiciosFactura
                .FirstOrDefaultAsync(m => m.Id_servicio == id);
            if (servicioFacturaModel == null)
            {
                return NotFound();
            }

            return View(servicioFacturaModel);
        }

        // GET: ServicioFacturaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioFacturaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_servicio,Id_Factura")] ServicioFacturaModel servicioFacturaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioFacturaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioFacturaModel);
        }

        // GET: ServicioFacturaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiciosFactura == null)
            {
                return NotFound();
            }

            var servicioFacturaModel = await _context.ServiciosFactura.FindAsync(id);
            if (servicioFacturaModel == null)
            {
                return NotFound();
            }
            return View(servicioFacturaModel);
        }

        // POST: ServicioFacturaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_servicio,Id_Factura")] ServicioFacturaModel servicioFacturaModel)
        {
            if (id != servicioFacturaModel.Id_servicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioFacturaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioFacturaModelExists(servicioFacturaModel.Id_servicio))
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
            return View(servicioFacturaModel);
        }

        // GET: ServicioFacturaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiciosFactura == null)
            {
                return NotFound();
            }

            var servicioFacturaModel = await _context.ServiciosFactura
                .FirstOrDefaultAsync(m => m.Id_servicio == id);
            if (servicioFacturaModel == null)
            {
                return NotFound();
            }

            return View(servicioFacturaModel);
        }

        // POST: ServicioFacturaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiciosFactura == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiciosFactura'  is null.");
            }
            var servicioFacturaModel = await _context.ServiciosFactura.FindAsync(id);
            if (servicioFacturaModel != null)
            {
                _context.ServiciosFactura.Remove(servicioFacturaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioFacturaModelExists(int id)
        {
          return (_context.ServiciosFactura?.Any(e => e.Id_servicio == id)).GetValueOrDefault();
        }
    }
}
