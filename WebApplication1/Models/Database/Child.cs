using System.Collections.Generic;

namespace WebApplication1.Models.Database
{
    public class Child
    {
        public Child()
        {
            this.FavoriteToys = new HashSet<Toy>();
        }

        public int Id { get; set; }

        public ICollection<Toy> FavoriteToys { get; set; }
    }
}