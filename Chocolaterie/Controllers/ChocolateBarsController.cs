using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.Data;
using Chocolaterie.Entities;

namespace Chocolaterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolateBarsController : ControllerBase
    {
        private readonly ChocolaterieContext _context;

        public ChocolateBarsController(ChocolaterieContext context)
        {
            _context = context;
        }

        // GET: api/ChocolateBars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChocolateBar>>> GetChocolateBar()
        {
          if (_context.ChocolateBars == null)
          {
              return NotFound();
          }
            return await _context.ChocolateBars.ToListAsync();
        }

        // GET: api/ChocolateBars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChocolateBar>> GetChocolateBar(int id)
        {
          if (_context.ChocolateBars == null)
          {
              return NotFound();
          }
            var chocolateBar = await _context.ChocolateBars.FindAsync(id);

            if (chocolateBar == null)
            {
                return NotFound();
            }

            return chocolateBar;
        }

        // PUT: api/ChocolateBars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChocolateBar(int id, ChocolateBar chocolateBar)
        {
            if (id != chocolateBar.Id)
            {
                return BadRequest();
            }

            _context.Entry(chocolateBar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChocolateBarExists(id))
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

        // POST: api/ChocolateBars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChocolateBar>> PostChocolateBar(ChocolateBar chocolateBar)
        {
          if (_context.ChocolateBars == null)
          {
              return Problem("Entity set 'ChocolaterieContext.ChocolateBars'  is null.");
          }
            _context.ChocolateBars.Add(chocolateBar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChocolateBar", new { id = chocolateBar.Id }, chocolateBar);
        }

        // DELETE: api/ChocolateBars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChocolateBar(int id)
        {
            if (_context.ChocolateBars == null)
            {
                return NotFound();
            }
            var chocolateBar = await _context.ChocolateBars.FindAsync(id);
            if (chocolateBar == null)
            {
                return NotFound();
            }

            _context.ChocolateBars.Remove(chocolateBar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChocolateBarExists(int id)
        {
            return (_context.ChocolateBars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
