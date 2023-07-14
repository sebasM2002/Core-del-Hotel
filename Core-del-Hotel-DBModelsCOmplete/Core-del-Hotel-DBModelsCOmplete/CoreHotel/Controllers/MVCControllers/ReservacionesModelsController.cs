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
    public class ReservacionesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservacionesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservacionesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservaciones.Where(x => x.is_Deleted != true).ToListAsync());
        }

        // GET: ReservacionesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservaciones == null)
            {
                return NotFound();
            }

            var reservacionesModel = await _context.Reservaciones
                .FirstOrDefaultAsync(m => m.Id_Reservacion == id);
            if (reservacionesModel == null)
            {
                return NotFound();
            }

            return View(reservacionesModel);
        }

        // POST: ReservacionesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservaciones'  is null.");
            }
            var reservacionesModel = await _context.Reservaciones.FindAsync(id);
            if (reservacionesModel != null)
            {
                reservacionesModel.is_Deleted = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionesModelExists(int id)
        {
          return (_context.Reservaciones?.Any(e => e.Id_Reservacion == id)).GetValueOrDefault();
        }
    }
}
