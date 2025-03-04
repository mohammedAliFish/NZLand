
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WNZland.CustomActionFilters;
using WNZland.Data;
using WNZland.Models.Domain;
using WNZland.Models.DTO;
using WNZland.Repositories;

namespace WNZland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        private readonly WNZDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        private readonly IMapper mapper;
        public RegionsController(WNZDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Authorize (Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();


            var regionDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionDto);
        }

        [HttpGet("{id:Guid}")]
         [Authorize (Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            
            var region = await regionRepository.GetByIdAsync(id);
            if (region == null)
                return NotFound();
            var regionDto = mapper.Map<RegionDto>(region);


            return Ok(regionDto);
        }
        [HttpPost]
        [ValidateModel]
         [Authorize (Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionDto)
        {

           
                var regionDomain = mapper.Map<Region>(regionDto);
                regionDomain = await regionRepository.CreateAsync(regionDomain);


                var regionDtos = mapper.Map<RegionDto>(regionDomain);
                return CreatedAtAction(nameof(GetById), new { id = regionDtos.Id }, regionDtos);
          




        }


        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize]        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
                if (regionDomainModel == null)
                    return NotFound();
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
          
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
                return NotFound();



            return Ok();
        }
    }
}
