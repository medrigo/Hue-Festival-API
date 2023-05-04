using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hue_Festival_API.Data;
using Hue_Festival_API.Models;

namespace Hue_Festival_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketLocationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TicketLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketLocation>>> GetTicketLocations()
        {
          if (_context.TicketLocations == null)
          {
              return NotFound();
          }
            return await _context.TicketLocations.ToListAsync();
        }

        // GET: api/TicketLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketLocation>> GetTicketLocation(int id)
        {
          if (_context.TicketLocations == null)
          {
              return NotFound();
          }
            var ticketLocation = await _context.TicketLocations.FindAsync(id);

            if (ticketLocation == null)
            {
                return NotFound();
            }

            return ticketLocation;
        }

        // PUT: api/TicketLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketLocation(int id, TicketLocation ticketLocation)
        {
            if (id != ticketLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketLocationExists(id))
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

        // POST: api/TicketLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketLocation>> PostTicketLocation(TicketLocation ticketLocation)
        {
          if (_context.TicketLocations == null)
          {
              return Problem("Entity set 'DataContext.TicketLocations'  is null.");
          }
            _context.TicketLocations.Add(ticketLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketLocation", new { id = ticketLocation.Id }, ticketLocation);
        }

        // DELETE: api/TicketLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketLocation(int id)
        {
            if (_context.TicketLocations == null)
            {
                return NotFound();
            }
            var ticketLocation = await _context.TicketLocations.FindAsync(id);
            if (ticketLocation == null)
            {
                return NotFound();
            }

            _context.TicketLocations.Remove(ticketLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketLocationExists(int id)
        {
            return (_context.TicketLocations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
