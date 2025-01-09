using System.Runtime.Serialization;

namespace WebApplication1.Models.Dto
{
    [KnownType(typeof(ToyADto))]
    [KnownType(typeof(ToyBDto))]
    public abstract class ToyDto : IToyDto
    {
        public int Id { get; set; }
    }
}