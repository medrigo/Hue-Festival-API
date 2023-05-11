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
    public class TicketTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TicketTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketType>>> GetTicketTypes()
        {
          if (_context.TicketTypes == null)
          {
              return NotFound();
          }
            return await _context.TicketTypes.ToListAsync();
        }

        // GET: api/TicketTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketType>> GetTicketType(int id)
        {
          if (_context.TicketTypes == null)
          {
              return NotFound();
          }
            var ticketType = await _context.TicketTypes.FindAsync(id);

            if (ticketType == null)
            {
                return NotFound();
            }

            return ticketType;
        }

        // PUT: api/TicketTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketType(int id, TicketType ticketType)
        {
            if (id != ticketType.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTypeExists(id))
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

        // POST: api/TicketTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketType>> PostTicketType(TicketType ticketType)
        {
          if (_context.TicketTypes == null)
          {
              return Problem("Entity set 'DataContext.TicketTypes'  is null.");
          }
            _context.TicketTypes.Add(ticketType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketType", new { id = ticketType.Id }, ticketType);
        }

        // DELETE: api/TicketTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketType(int id)
        {
            if (_context.TicketTypes == null)
            {
                return NotFound();
            }
            var ticketType = await _context.TicketTypes.FindAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            _context.TicketTypes.Remove(ticketType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketTypeExists(int id)
        {
            return (_context.TicketTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
