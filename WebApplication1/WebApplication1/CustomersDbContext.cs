using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Counter> Counters { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
