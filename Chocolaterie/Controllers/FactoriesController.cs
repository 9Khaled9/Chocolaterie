using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.Data;
using Chocolaterie.Models;

namespace Chocolaterie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly ChocolaterieContext _context;

        public FactoriesController(ChocolaterieContext context)
        {
            _context = context;
        }

        // GET: api/Factories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factory>>> GetFactory()
        {
          if (_context.Factory == null)
          {
              return NotFound();
          }
            return await _context.Factory.ToListAsync();
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factory>> GetFactory(int id)
        {
          if (_context.Factory == null)
          {
              return NotFound();
          }
            var factory = await _context.Factory.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return factory;
        }

        // PUT: api/Factories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactory(int id, Factory factory)
        {
            if (id != factory.Id)
            {
                return BadRequest();
            }

            _context.Entry(factory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryExists(id))
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

        // POST: api/Factories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factory>> PostFactory(Factory factory)
        {
          if (_context.Factory == null)
          {
              return Problem("Entity set 'ChocolaterieContext.Factory'  is null.");
          }
            _context.Factory.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factory.Id }, factory);
        }

        // DELETE: api/Factories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory(int id)
        {
            if (_context.Factory == null)
            {
                return NotFound();
            }
            var factory = await _context.Factory.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }

            _context.Factory.Remove(factory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactoryExists(int id)
        {
            return (_context.Factory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
