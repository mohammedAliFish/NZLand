

using WNZland.Models.Domain;

namespace WNZland.Repositories;

public interface IWalkRepository
{
    Task <Walk> CreateAsync(Walk walk);
    Task <List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,string? sortBy=null , bool isAscending=true , int pageNumber = 1, int pageSize = 10);
    Task <Walk> GetAsync(Guid id);
    Task UpdateAsync(Walk walk);

    Task <Walk?> DeleteAsync(Guid id);
}
