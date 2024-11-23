using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly CustomersDbContext _context;

        public CounterController(CustomersDbContext context)
        {
            _context = context;
        }

        // GET: api/CounterEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Counter>>> GetCounters()
        {
            return await _context.Counters.ToListAsync();
        }

        // GET: api/CounterEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Counter>> GetCounterEntity(int id)
        {
            var counterEntity = await _context.Counters.FindAsync(id);

            if (counterEntity == null)
            {
                return NotFound();
            }

            return counterEntity;
        }

        // PUT: api/CounterEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounterEntity(int id, Counter counterEntity)
        {
            if (id != counterEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(counterEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CounterEntityExists(id))
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

        // POST: api/CounterEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Counter>> PostCounterEntity(Counter counterEntity)
        {
            _context.Counters.Add(counterEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCounterEntity", new { id = counterEntity.Id }, counterEntity);
        }

        // DELETE: api/CounterEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounterEntity(int id)
        {
            var counterEntity = await _context.Counters.FindAsync(id);
            if (counterEntity == null)
            {
                return NotFound();
            }

            _context.Counters.Remove(counterEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CounterEntityExists(int id)
        {
            return _context.Counters.Any(e => e.Id == id);
        }
    }
}
