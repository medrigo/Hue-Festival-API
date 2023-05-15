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
    public class HelpMenusController : ControllerBase
    {
        private readonly DataContext _context;

        public HelpMenusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/HelpMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HelpMenu>>> GetHelpMenus()
        {
          if (_context.HelpMenus == null)
          {
              return NotFound();
          }
            return await _context.HelpMenus.ToListAsync();
        }

        // GET: api/HelpMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HelpMenu>> GetHelpMenu(int id)
        {
          if (_context.HelpMenus == null)
          {
              return NotFound();
          }
            var helpMenu = await _context.HelpMenus.FindAsync(id);

            if (helpMenu == null)
            {
                return NotFound();
            }

            return helpMenu;
        }

        // PUT: api/HelpMenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelpMenu(int id, HelpMenu helpMenu)
        {
            if (id != helpMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(helpMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpMenuExists(id))
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

        // POST: api/HelpMenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HelpMenu>> PostHelpMenu(HelpMenu helpMenu)
        {
          if (_context.HelpMenus == null)
          {
              return Problem("Entity set 'DataContext.HelpMenus'  is null.");
          }
            _context.HelpMenus.Add(helpMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelpMenu", new { id = helpMenu.Id }, helpMenu);
        }

        // DELETE: api/HelpMenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelpMenu(int id)
        {
            if (_context.HelpMenus == null)
            {
                return NotFound();
            }
            var helpMenu = await _context.HelpMenus.FindAsync(id);
            if (helpMenu == null)
            {
                return NotFound();
            }

            _context.HelpMenus.Remove(helpMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HelpMenuExists(int id)
        {
            return (_context.HelpMenus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
