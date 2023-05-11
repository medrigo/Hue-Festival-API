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
    public class ProgramTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProgramTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramType>>> GetProgramTypes()
        {
          if (_context.ProgramTypes == null)
          {
              return NotFound();
          }
            return await _context.ProgramTypes.ToListAsync();
        }

        // GET: api/ProgramTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramType>> GetProgramType(int id)
        {
          if (_context.ProgramTypes == null)
          {
              return NotFound();
          }
            var programType = await _context.ProgramTypes.FindAsync(id);

            if (programType == null)
            {
                return NotFound();
            }

            return programType;
        }

        // PUT: api/ProgramTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramType(int id, ProgramType programType)
        {
            if (id != programType.Id)
            {
                return BadRequest();
            }

            _context.Entry(programType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramTypeExists(id))
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

        // POST: api/ProgramTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramType>> PostProgramType(ProgramType programType)
        {
          if (_context.ProgramTypes == null)
          {
              return Problem("Entity set 'DataContext.ProgramTypes'  is null.");
          }
            _context.ProgramTypes.Add(programType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramType", new { id = programType.Id }, programType);
        }

        // DELETE: api/ProgramTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramType(int id)
        {
            if (_context.ProgramTypes == null)
            {
                return NotFound();
            }
            var programType = await _context.ProgramTypes.FindAsync(id);
            if (programType == null)
            {
                return NotFound();
            }

            _context.ProgramTypes.Remove(programType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramTypeExists(int id)
        {
            return (_context.ProgramTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
