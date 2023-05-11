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
    public class LocationWishlistsController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationWishlistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LocationWishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationWishlist>>> GetlocationWishlists()
        {
          if (_context.locationWishlists == null)
          {
              return NotFound();
          }
            return await _context.locationWishlists.ToListAsync();
        }

        // GET: api/LocationWishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationWishlist>> GetLocationWishlist(int id)
        {
          if (_context.locationWishlists == null)
          {
              return NotFound();
          }
            var locationWishlist = await _context.locationWishlists.FindAsync(id);

            if (locationWishlist == null)
            {
                return NotFound();
            }

            return locationWishlist;
        }

        // PUT: api/LocationWishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationWishlist(int id, LocationWishlist locationWishlist)
        {
            if (id != locationWishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationWishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationWishlistExists(id))
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

        // POST: api/LocationWishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationWishlist>> PostLocationWishlist(LocationWishlist locationWishlist)
        {
          if (_context.locationWishlists == null)
          {
              return Problem("Entity set 'DataContext.locationWishlists'  is null.");
          }
            _context.locationWishlists.Add(locationWishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationWishlist", new { id = locationWishlist.Id }, locationWishlist);
        }

        // DELETE: api/LocationWishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationWishlist(int id)
        {
            if (_context.locationWishlists == null)
            {
                return NotFound();
            }
            var locationWishlist = await _context.locationWishlists.FindAsync(id);
            if (locationWishlist == null)
            {
                return NotFound();
            }

            _context.locationWishlists.Remove(locationWishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationWishlistExists(int id)
        {
            return (_context.locationWishlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
