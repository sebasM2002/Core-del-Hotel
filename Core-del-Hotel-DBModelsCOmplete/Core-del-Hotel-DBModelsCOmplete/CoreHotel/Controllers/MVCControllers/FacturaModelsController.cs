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
    public class FacturaModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facturas.Where(x => x.is_deleted != true).ToListAsync());
        }
    }
}
