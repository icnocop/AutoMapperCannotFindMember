using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication1.Models.Dto
{
    public class ChildDto
    {
        public int Id { get; set; }

        public ICollection<ToyDto> FavoriteToys { get; set; }
    }
}
