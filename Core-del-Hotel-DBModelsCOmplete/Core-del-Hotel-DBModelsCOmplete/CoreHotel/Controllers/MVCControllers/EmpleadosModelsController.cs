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
    public class EmpleadosModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmpleadosModelsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: EmpleadosModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.Where(x => x.Is_deleted != true).ToListAsync());
        }

        // GET: EmpleadosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleadosModel = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id_Empleados == id);
            if (empleadosModel == null)
            {
                return NotFound();
            }

            return View(empleadosModel);
        }

        // GET: EmpleadosModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrarEmpleadoDTO empleadoModel)
        {
            if (empleadoModel.email == null || empleadoModel.password == null)
            {
                if (ModelState.IsValid)
                {
                    EmpleadosModel empleado = new EmpleadosModel();
                    empleado.Nombre = empleadoModel.Nombre;
                    empleado.Telefono = empleadoModel.Telefono;
                    empleado.Direccion = empleadoModel.Direccion;
                    empleado.Sueldo = empleadoModel.Sueldo;
                    empleado.Created_at = DateTime.Now.ToString();
                    empleado.Is_deleted = false;
                    _context.Add(empleado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(empleadoModel);
            }
            else
            {
                var user = new IdentityUser { UserName = empleadoModel.email, Email = empleadoModel.email };
                var result = await _userManager.CreateAsync(user, empleadoModel.password);

                if (result.Succeeded)
                {
                    if (ModelState.IsValid)
                    {
                        EmpleadosModel empleado = new EmpleadosModel();
                        empleado.Nombre = empleadoModel.Nombre;
                        empleado.Telefono = empleadoModel.Telefono;
                        empleado.Direccion = empleadoModel.Direccion;
                        empleado.Sueldo = empleadoModel.Sueldo;
                        empleado.Created_at = DateTime.Now.ToString();
                        empleado.Id_Usuario = user.Id;
                        empleado.Is_deleted = false;
                        _context.Add(empleado);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(empleadoModel);
                }
                else
                {
                    return BadRequest("Username or password invalid");
                }
            }
        }

        // GET: EmpleadosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleadosModel = await _context.Empleados.FindAsync(id);
            if (empleadosModel == null)
            {
                return NotFound();
            }
            return View(empleadosModel);
        }

        // POST: EmpleadosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Empleados,Nombre,Direccion,Telefono,Sueldo,Id_Usuario,Is_deleted,Created_at,Updated_at")] EmpleadosModel empleadosModel)
        {
            if (id != empleadosModel.Id_Empleados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    empleadosModel.Updated_at = DateTime.Now.ToString();
                    _context.Update(empleadosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosModelExists(empleadosModel.Id_Empleados))
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
            return View(empleadosModel);
        }

        // GET: EmpleadosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleadosModel = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id_Empleados == id);
            if (empleadosModel == null)
            {
                return NotFound();
            }

            return View(empleadosModel);
        }
        // POST: EmpleadosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Empleados'  is null.");
            }
            var empleadosModel = await _context.Empleados.FindAsync(id);
            if (empleadosModel != null)
            {
                empleadosModel.Is_deleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosModelExists(int id)
        {
            return (_context.Empleados?.Any(e => e.Id_Empleados == id)).GetValueOrDefault();
        }
    }
}
