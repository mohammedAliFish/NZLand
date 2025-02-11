using System;
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
}
