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
    public class ProgramWishlistsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramWishlistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProgramWishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramWishlist>>> GetProgramWishlists()
        {
          if (_context.ProgramWishlists == null)
          {
              return NotFound();
          }
            return await _context.ProgramWishlists.ToListAsync();
        }

        // GET: api/ProgramWishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramWishlist>> GetProgramWishlist(int id)
        {
          if (_context.ProgramWishlists == null)
          {
              return NotFound();
          }
            var programWishlist = await _context.ProgramWishlists.FindAsync(id);

            if (programWishlist == null)
            {
                return NotFound();
            }

            return programWishlist;
        }

        // PUT: api/ProgramWishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramWishlist(int id, ProgramWishlist programWishlist)
        {
            if (id != programWishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(programWishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramWishlistExists(id))
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

        // POST: api/ProgramWishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramWishlist>> PostProgramWishlist(ProgramWishlist programWishlist)
        {
          if (_context.ProgramWishlists == null)
          {
              return Problem("Entity set 'DataContext.ProgramWishlists'  is null.");
          }
            _context.ProgramWishlists.Add(programWishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramWishlist", new { id = programWishlist.Id }, programWishlist);
        }

        // DELETE: api/ProgramWishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramWishlist(int id)
        {
            if (_context.ProgramWishlists == null)
            {
                return NotFound();
            }
            var programWishlist = await _context.ProgramWishlists.FindAsync(id);
            if (programWishlist == null)
            {
                return NotFound();
            }

            _context.ProgramWishlists.Remove(programWishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramWishlistExists(int id)
        {
            return (_context.ProgramWishlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
