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
    public class LocationTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LocationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationType>>> GetLocationTypes()
        {
          if (_context.LocationTypes == null)
          {
              return NotFound();
          }
            return await _context.LocationTypes.ToListAsync();
        }

        // GET: api/LocationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationType>> GetLocationType(int id)
        {
          if (_context.LocationTypes == null)
          {
              return NotFound();
          }
            var locationType = await _context.LocationTypes.FindAsync(id);

            if (locationType == null)
            {
                return NotFound();
            }

            return locationType;
        }

        // PUT: api/LocationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationType(int id, LocationType locationType)
        {
            if (id != locationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(locationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationTypeExists(id))
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

        // POST: api/LocationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationType>> PostLocationType(LocationType locationType)
        {
          if (_context.LocationTypes == null)
          {
              return Problem("Entity set 'DataContext.LocationTypes'  is null.");
          }
            _context.LocationTypes.Add(locationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationType", new { id = locationType.Id }, locationType);
        }

        // DELETE: api/LocationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationType(int id)
        {
            if (_context.LocationTypes == null)
            {
                return NotFound();
            }
            var locationType = await _context.LocationTypes.FindAsync(id);
            if (locationType == null)
            {
                return NotFound();
            }

            _context.LocationTypes.Remove(locationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationTypeExists(int id)
        {
            return (_context.LocationTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
