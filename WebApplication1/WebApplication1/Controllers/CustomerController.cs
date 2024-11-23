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
    public class CustomerController : ControllerBase
    {
        private readonly CustomersDbContext _context;

        public CustomerController(CustomersDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/CustomerEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            return customerEntity;
        }

        // PUT: api/CustomerEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, Customer customerEntity)
        {
            if (id != customerEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEntityExists(id))
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

        // POST: api/CustomerEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomerEntity(Customer customerEntity)
        {
            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerEntity", new { id = customerEntity.Id }, customerEntity);
        }

        // DELETE: api/CustomerEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerEntityExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
