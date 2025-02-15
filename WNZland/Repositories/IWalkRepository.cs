

using WNZland.Models.Domain;

namespace WNZland.Repositories;

public interface IWalkRepository
{
    Task <Walk> CreateAsync(Walk walk);
    Task <List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
    Task <Walk> GetAsync(Guid id);
    Task UpdateAsync(Walk walk);

    Task <Walk?> DeleteAsync(Guid id);
}
