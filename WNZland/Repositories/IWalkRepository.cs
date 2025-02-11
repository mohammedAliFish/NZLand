

using WNZland.Models.Domain;

namespace WNZland.Repositories;

public interface IWalkRepository
{
    Task <Walk> CreateAsync(Walk walk);
}
