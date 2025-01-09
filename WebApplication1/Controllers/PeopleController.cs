namespace WebApplication1.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using WebApplication1.Models;
    using WebApplication1.Models.Dto;

    [Route("api")]
    public class PeopleController : ODataController
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;

        public PeopleController(
            AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        [HttpGet("People")]
        public async Task<IQueryable<PersonDto>> GetAsync(ODataQueryOptions<PersonDto> queryOptions)
        {
            return await _context.People
                .GetQueryAsync(
                    this.mapper,
                    queryOptions,
                    new QuerySettings
                    {
                        ODataSettings = new ODataSettings
                        {
                            HandleNullPropagation = HandleNullPropagationOption.Default,
                        },
                    });
        }
    }
}
