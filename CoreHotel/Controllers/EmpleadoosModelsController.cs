using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;

namespace CoreHotel.Controllers
{
    public class EmpleadoosModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoosModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadoosModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empleados.Include(e => e.PaisModel).Include(e => e.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmpleadoosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleadoosModel = await _context.Empleados
                .Include(e => e.PaisModel)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id_Empleados == id);
            if (empleadoosModel == null)
            {
                return NotFound();
            }

            return View(empleadoosModel);
        }

        // GET: EmpleadoosModels/Create
        public IActionResult Create()
        {
            ViewData["Id_Pais"] = new SelectList(_context.Paises, "Id_Pais", "Name");
            ViewData["Id_Usuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: EmpleadoosModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Empleados,Nombre,Id_Pais,Direccion,Telefono,Correo_electronico,Sueldo,Id_Usuario,Is_deleted,Created_at,Updated_at")] EmpleadoosModel empleadoosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleadoosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Pais"] = new SelectList(_context.Paises, "Id_Pais", "Name", empleadoosModel.Id_Pais);
            ViewData["Id_Usuario"] = new SelectList(_context.Users, "Id", "Id", empleadoosModel.Id_Usuario);
            return View(empleadoosModel);
        }

        // GET: EmpleadoosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleadoosModel = await _context.Empleados.FindAsync(id);
            if (empleadoosModel == null)
            {
                return NotFound();
            }
            ViewData["Id_Pais"] = new SelectList(_context.Paises, "Id_Pais", "Name", empleadoosModel.Id_Pais);
            ViewData["Id_Usuario"] = new SelectList(_context.Users, "Id", "Id", empleadoosModel.Id_Usuario);
            return View(empleadoosModel);
        }

        // POST: EmpleadoosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Empleados,Nombre,Id_Pais,Direccion,Telefono,Correo_electronico,Sueldo,Id_Usuario,Is_deleted,Created_at,Updated_at")] EmpleadoosModel empleadoosModel)
        {
            if (id != empleadoosModel.Id_Empleados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleadoosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoosModelExists(empleadoosModel.Id_Empleados))
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
            ViewData["Id_Pais"] = new SelectList(_context.Paises, "Id_Pais", "Name", empleadoosModel.Id_Pais);
            ViewData["Id_Usuario"] = new SelectList(_context.Users, "Id", "Id", empleadoosModel.Id_Usuario);
            return View(empleadoosModel);
        }

        // GET: EmpleadoosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleadoosModel = await _context.Empleados
                .Include(e => e.PaisModel)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id_Empleados == id);
            if (empleadoosModel == null)
            {
                return NotFound();
            }

            return View(empleadoosModel);
        }

        // POST: EmpleadoosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Empleados'  is null.");
            }
            var empleadoosModel = await _context.Empleados.FindAsync(id);
            if (empleadoosModel != null)
            {
                _context.Empleados.Remove(empleadoosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoosModelExists(int id)
        {
          return (_context.Empleados?.Any(e => e.Id_Empleados == id)).GetValueOrDefault();
        }
    }
}
