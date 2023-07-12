using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreHotel.DTO;
using CoreHotel.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CoreHotel.Controllers.MVCControllers
{
    [Authorize(Roles = "Admin")]
    public class RoleDTOesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleDTOesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string roleId, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                role.Name = roleName;
                await _roleManager.UpdateAsync(role);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }

        //private readonly ApplicationDbContext _context;

        //public RoleDTOesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: RoleDTOes
        //public async Task<IActionResult> Index()
        //{
        //      return _context.RoleDTO != null ? 
        //                  View(await _context.RoleDTO.ToListAsync()) :
        //                  Problem("Entity set 'ApplicationDbContext.RoleDTO'  is null.");
        //}

        //// GET: RoleDTOes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.RoleDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleDTO = await _context.RoleDTO
        //        .FirstOrDefaultAsync(m => m.Rol_Id == id);
        //    if (roleDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(roleDTO);
        //}

        //// GET: RoleDTOes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RoleDTOes/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Rol_Id,Name")] RoleDTO roleDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(roleDTO);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(roleDTO);
        //}

        //// GET: RoleDTOes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.RoleDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleDTO = await _context.RoleDTO.FindAsync(id);
        //    if (roleDTO == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(roleDTO);
        //}

        //// POST: RoleDTOes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Rol_Id,Name")] RoleDTO roleDTO)
        //{
        //    if (id != roleDTO.Rol_Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(roleDTO);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoleDTOExists(roleDTO.Rol_Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(roleDTO);
        //}

        //// GET: RoleDTOes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.RoleDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleDTO = await _context.RoleDTO
        //        .FirstOrDefaultAsync(m => m.Rol_Id == id);
        //    if (roleDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(roleDTO);
        //}

        //// POST: RoleDTOes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.RoleDTO == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.RoleDTO'  is null.");
        //    }
        //    var roleDTO = await _context.RoleDTO.FindAsync(id);
        //    if (roleDTO != null)
        //    {
        //        _context.RoleDTO.Remove(roleDTO);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RoleDTOExists(int id)
        //{
        //  return (_context.RoleDTO?.Any(e => e.Rol_Id == id)).GetValueOrDefault();
        //}
    }
}
