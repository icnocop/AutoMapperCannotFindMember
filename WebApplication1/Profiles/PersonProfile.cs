using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.Database;
using WebApplication1.Models.Dto;

namespace WebApplication1.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();

            CreateMap<Child, ChildDto>();

            CreateMap<Toy, IToyDto>()
                .As<ToyADto>();

            CreateMap<Toy, ToyADto>();
        }
    }
}
