
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

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

        public IActionResult GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id); or
            var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);
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
        public IActionResult Create([FromBody] AddRegionRequestDto regionDto)
        {
            var regionDomain = new Region
            {
                Name = regionDto.Name,
                Code = regionDto.Code,
                RegionImageUrl = regionDto.RegionImageUrl
            };
            dbContext.Regions.Add(regionDomain);
            dbContext.SaveChanges();

            var regionDtos = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDtos.Id }, regionDtos);
    
        }
    }
}
