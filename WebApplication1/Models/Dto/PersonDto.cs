using System.Collections.Generic;

namespace WebApplication1.Models.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ChildDto> Children { get; set; }
    }
}
