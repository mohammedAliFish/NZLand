
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WNZland.Data;
using WNZland.Models.Domain;
using WNZland.Models.DTO;

namespace WNZland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WNZDbContext dbContext;
        public RegionsController(WNZDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await dbContext.Regions.ToListAsync ();

            var regionDto = new List<RegionDto>();

            foreach (var region in regions)
            {
                regionDto.Add(new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return Ok(regionDto);
        }

        [HttpGet("{id:Guid}")]

        public async  Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id); or
            var region = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null)
                return NotFound();
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };


            return Ok(regionDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionDto)
        {
            var regionDomain = new Region
            {
                Name = regionDto.Name,
                Code = regionDto.Code,
                RegionImageUrl = regionDto.RegionImageUrl
            };
            await dbContext.Regions.AddAsync(regionDomain);
            await dbContext.SaveChangesAsync();

            var regionDtos = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDtos.Id }, regionDtos);

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
                return NotFound();

                regionDomainModel.Name = updateRegionRequestDto.Name;
                regionDomainModel.Code = updateRegionRequestDto.Code;
                regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

           await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
    
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id ==id);
            if(region == null)
            return NotFound();

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
