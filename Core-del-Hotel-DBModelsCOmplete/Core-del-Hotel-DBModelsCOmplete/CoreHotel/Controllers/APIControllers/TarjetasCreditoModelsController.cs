﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreHotel.Data;
using CoreHotel.Models;

namespace CoreHotel.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetasCreditoModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TarjetasCreditoModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TarjetasCreditoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarjetasCreditoModel>>> GetTarjetas()
        {
          if (_context.Tarjetas == null)
          {
              return NotFound();
          }
            return await _context.Tarjetas.ToListAsync();
        }

        // GET: api/TarjetasCreditoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetasCreditoModel>> GetTarjetasCreditoModel(int id)
        {
          if (_context.Tarjetas == null)
          {
              return NotFound();
          }
            var tarjetasCreditoModel = await _context.Tarjetas.FindAsync(id);

            if (tarjetasCreditoModel == null)
            {
                return NotFound();
            }

            return tarjetasCreditoModel;
        }

        // PUT: api/TarjetasCreditoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetasCreditoModel(int id, TarjetasCreditoModel tarjetasCreditoModel)
        {
            if (id != tarjetasCreditoModel.Id_tarjeta)
            {
                return BadRequest();
            }

            _context.Entry(tarjetasCreditoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetasCreditoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TarjetasCreditoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TarjetasCreditoModel>> PostTarjetasCreditoModel(TarjetasCreditoModel tarjetasCreditoModel)
        {
          if (_context.Tarjetas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Tarjetas'  is null.");
          }
            _context.Tarjetas.Add(tarjetasCreditoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetasCreditoModel", new { id = tarjetasCreditoModel.Id_tarjeta }, tarjetasCreditoModel);
        }

        // DELETE: api/TarjetasCreditoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarjetasCreditoModel(int id)
        {
            if (_context.Tarjetas == null)
            {
                return NotFound();
            }
            var tarjetasCreditoModel = await _context.Tarjetas.FindAsync(id);
            if (tarjetasCreditoModel == null)
            {
                return NotFound();
            }

            _context.Tarjetas.Remove(tarjetasCreditoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarjetasCreditoModelExists(int id)
        {
            return (_context.Tarjetas?.Any(e => e.Id_tarjeta == id)).GetValueOrDefault();
        }
    }
}
