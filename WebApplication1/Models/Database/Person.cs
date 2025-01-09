using System.Collections.Generic;
using WebApplication1.Models.Database;

namespace WebApplication1.Models
{
    public class Person
    {
        public Person()
        {
            this.Children = new HashSet<Child>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
