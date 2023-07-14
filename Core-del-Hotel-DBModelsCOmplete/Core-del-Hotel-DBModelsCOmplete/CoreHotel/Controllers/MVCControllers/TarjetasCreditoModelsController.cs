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
    public class TarjetasCreditoModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarjetasCreditoModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TarjetasCreditoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tarjetas.Where(x => x.Is_deleted != true).ToListAsync());
        }
    }
}
