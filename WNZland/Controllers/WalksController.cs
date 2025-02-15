using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WNZland.CustomActionFilters;
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
        public WalksController(IMapper mapper, IWalkRepository SQLRegionRepositories)
        {
            this.mapper = mapper;
            this.SQLRegionRepositories = SQLRegionRepositories;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
          
                var walkDomain = mapper.Map<Walk>(addWalkRequestDto);
                walkDomain = await SQLRegionRepositories.CreateAsync(walkDomain);

                return Ok(mapper.Map<WalkDto>(walkDomain));
          


        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn , [FromQuery] string? filterQuery, [FromQuery] string? sortBy , [FromQuery] bool? isAscending , [FromQuery] int pageNumber , [FromQuery] int pageSize)
        {
            var walks = await SQLRegionRepositories.GetAllAsync(filterOn,filterQuery,sortBy,isAscending ?? true , pageNumber , pageSize );
            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await SQLRegionRepositories.GetAsync(id);
            return Ok(mapper.Map<WalkDto>(walk));
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            
                var walk = await SQLRegionRepositories.GetAsync(id);
                if (walk == null)
                {
                    return NotFound();
                }
                mapper.Map(updateWalkRequestDto, walk);
                await SQLRegionRepositories.UpdateAsync(walk);
                return Ok(mapper.Map<WalkDto>(walk));
           

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walk = await SQLRegionRepositories.GetAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(await SQLRegionRepositories.DeleteAsync(id)));

        }

    }
}
