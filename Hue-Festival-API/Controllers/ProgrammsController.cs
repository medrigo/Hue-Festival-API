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
    public class ProgrammsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgrammsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Programms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programm>>> GetPrograms()
        {
          if (_context.Programs == null)
          {
              return NotFound();
          }
            return await _context.Programs.ToListAsync();
        }

        // GET: api/Programms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programm>> GetProgramm(int id)
        {
          if (_context.Programs == null)
          {
              return NotFound();
          }
            var programm = await _context.Programs.FindAsync(id);

            if (programm == null)
            {
                return NotFound();
            }

            return programm;
        }

        // PUT: api/Programms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramm(int id, Programm programm)
        {
            if (id != programm.Id)
            {
                return BadRequest();
            }

            _context.Entry(programm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammExists(id))
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

        // POST: api/Programms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Programm>> PostProgramm(Programm programm)
        {
          if (_context.Programs == null)
          {
              return Problem("Entity set 'DataContext.Programs'  is null.");
          }
            _context.Programs.Add(programm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramm", new { id = programm.Id }, programm);
        }

        // DELETE: api/Programms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramm(int id)
        {
            if (_context.Programs == null)
            {
                return NotFound();
            }
            var programm = await _context.Programs.FindAsync(id);
            if (programm == null)
            {
                return NotFound();
            }

            _context.Programs.Remove(programm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgrammExists(int id)
        {
            return (_context.Programs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
