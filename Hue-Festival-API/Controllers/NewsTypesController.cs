using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hue_Festival_API.Data;
using Hue_Festival_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hue_Festival_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NewsTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public NewsTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/NewsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsType>>> GetNewsTypes()
        {
          if (_context.NewsTypes == null)
          {
              return NotFound();
          }
            return await _context.NewsTypes.ToListAsync();
        }

        // GET: api/NewsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsType>> GetNewsType(int id)
        {
          if (_context.NewsTypes == null)
          {
              return NotFound();
          }
            var newsType = await _context.NewsTypes.FindAsync(id);

            if (newsType == null)
            {
                return NotFound();
            }

            return newsType;
        }

        // PUT: api/NewsTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsType(int id, NewsType newsType)
        {
            if (id != newsType.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsTypeExists(id))
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

        // POST: api/NewsTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewsType>> PostNewsType(NewsType newsType)
        {
          if (_context.NewsTypes == null)
          {
              return Problem("Entity set 'DataContext.NewsTypes'  is null.");
          }
            _context.NewsTypes.Add(newsType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsType", new { id = newsType.Id }, newsType);
        }

        // DELETE: api/NewsTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsType(int id)
        {
            if (_context.NewsTypes == null)
            {
                return NotFound();
            }
            var newsType = await _context.NewsTypes.FindAsync(id);
            if (newsType == null)
            {
                return NotFound();
            }

            _context.NewsTypes.Remove(newsType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsTypeExists(int id)
        {
            return (_context.NewsTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
