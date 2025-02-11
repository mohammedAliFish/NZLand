
using Microsoft.EntityFrameworkCore;
using WNZland.Data;
using WNZland.Models.Domain;
namespace WNZland.Repositories;

public class SQLRegionRepositories : IRegionRepository
{
    private readonly WNZDbContext dbContext;
    public SQLRegionRepositories(WNZDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<List<Region>> GetAllAsync()
    {
        return await dbContext.Regions.ToListAsync(); 
    }
    public async Task<Region> GetByIdAsync(Guid id)
    {
        return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
    }
    public async Task<Region> CreateAsync(Region region)
    {
        dbContext.Regions.AddAsync(region);
        await dbContext.SaveChangesAsync();
        return region;
    }
    public async Task<Region?> UpdateAsync(Guid id ,Region region)
    {
        var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
       if (existingRegion == null) return null;

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            await dbContext.SaveChangesAsync();
        
       
        return existingRegion;
    }

   public async Task<Region> DeleteAsync(Guid id)
    {
        var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion != null)
        {
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
        }
        return existingRegion;
    }
}
