using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WNZland.Models.Domain;
using WNZland.Models.DTO;
using WNZland.Repositories;
namespace WNZland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository SQLRegionRepositories;
        public WalksController(IMapper mapper , IWalkRepository SQLRegionRepositories)
        {
            this.mapper = mapper;
            this.SQLRegionRepositories = SQLRegionRepositories;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           var walkDomain = mapper.Map<Walk>(addWalkRequestDto);
           walkDomain = await SQLRegionRepositories.CreateAsync(walkDomain);

           return Ok(mapper.Map<WalkDto>(walkDomain));
               

        }
    }
}
