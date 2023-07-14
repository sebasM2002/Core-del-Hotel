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
        private bool ServicioFacturaModelExists(int id)
        {
          return (_context.ServiciosFactura?.Any(e => e.Id_servicio == id)).GetValueOrDefault();
        }
    }
}
