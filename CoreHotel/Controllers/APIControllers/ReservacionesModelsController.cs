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
    public class ReservacionesModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservacionesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservacionesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservacionesModel>>> GetReservaciones()
        {
          if (_context.Reservaciones == null)
          {
              return NotFound();
          }
            return await _context.Reservaciones.ToListAsync();
        }

        // GET: api/ReservacionesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservacionesModel>> GetReservacionesModel(int id)
        {
          if (_context.Reservaciones == null)
          {
              return NotFound();
          }
            var reservacionesModel = await _context.Reservaciones.FindAsync(id);

            if (reservacionesModel == null)
            {
                return NotFound();
            }

            return reservacionesModel;
        }

        // PUT: api/ReservacionesModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacionesModel(int id, ReservacionesModel reservacionesModel)
        {
            if (id != reservacionesModel.Id_Reservacion)
            {
                return BadRequest();
            }

            _context.Entry(reservacionesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionesModelExists(id))
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

        // POST: api/ReservacionesModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservacionesModel>> PostReservacionesModel(ReservacionesModel reservacionesModel)
        {
          if (_context.Reservaciones == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Reservaciones'  is null.");
          }
            _context.Reservaciones.Add(reservacionesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservacionesModel", new { id = reservacionesModel.Id_Reservacion }, reservacionesModel);
        }

        // DELETE: api/ReservacionesModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacionesModel(int id)
        {
            if (_context.Reservaciones == null)
            {
                return NotFound();
            }
            var reservacionesModel = await _context.Reservaciones.FindAsync(id);
            if (reservacionesModel == null)
            {
                return NotFound();
            }

            _context.Reservaciones.Remove(reservacionesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservacionesModelExists(int id)
        {
            return (_context.Reservaciones?.Any(e => e.Id_Reservacion == id)).GetValueOrDefault();
        }
    }
}
