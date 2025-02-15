using Microsoft.EntityFrameworkCore;
using WNZland.Data;
using WNZland.Models.Domain;

namespace WNZland.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly WNZDbContext dbContext;
    public SQLWalkRepository(WNZDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Walk> CreateAsync(Walk walk)
    {
        await dbContext.Walks.AddAsync(walk);
        await dbContext.SaveChangesAsync();

        return walk;
    }
    public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null ,string? sortBy=null , bool isAscending=true , int pageNumber = 1, int pageSize = 10)
    {
         var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();



         if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
         {
           if(filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
           {
            walks = walks.Where(w => w.Name.Contains(filterQuery));
           }
         }

        if(string.IsNullOrWhiteSpace(sortBy) == false)
        {
            if(sortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
            {
                    walks = isAscending ? walks.OrderBy(w => w.Name):walks.OrderByDescending(w => w.Name);  
            }
        }


        var skipResults = (pageNumber - 1) * pageSize;


        return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
    }
    public async Task<Walk> GetAsync(Guid id)
    {
       

        return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(w => w.Id == id);
    }
    public async Task UpdateAsync(Walk walk)
    {
        dbContext.Walks.Update(walk);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        var walk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
        if (walk == null)
        {
            return null;
        }
        dbContext.Walks.Remove(walk);
        await dbContext.SaveChangesAsync();
        return walk;
    }
}
