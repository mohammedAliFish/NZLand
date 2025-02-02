
using Microsoft.AspNetCore.Mvc;
using WNZland.Data;

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
            return Ok(regions);
         }

            [HttpGet("{id:Guid}")]

            public IActionResult GetById([FromRoute] Guid id)
            {
               // var region = dbContext.Regions.Find(id);
               var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);
                if(region == null)
                return NotFound();
                return Ok(region);
            }
    }
}
