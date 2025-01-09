using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Database;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Child> Children { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
