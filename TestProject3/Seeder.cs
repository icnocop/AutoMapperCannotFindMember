using WebApplication1.Models;
using WebApplication1.Models.Database;

namespace TestProject3
{
    public class Seeder
    {
        private readonly AppDbContext _context;

        public Seeder(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Clear the existing data from the context
            _context.People.RemoveRange(_context.People);
            _context.Children.RemoveRange(_context.Children);

            _context.SaveChanges();

            var people = Enumerable.Range(0, 1)
                .Select(i => new Person
                {
                    Id = i,
                    FirstName = $"First Name {i}",
                    LastName = $"Last Name {i}",
                    Children = new List<Child>
                    {
                        new Child
                        {
                            Id = i,
                            FavoriteToys = new List<Toy>
                            {
                                new Toy
                                {
                                    Id = i,
                                },
                            }
                        }
                    }
                }).ToList();

            _context.People.AddRange(people);
            _context.SaveChanges();
        }
    }
}
