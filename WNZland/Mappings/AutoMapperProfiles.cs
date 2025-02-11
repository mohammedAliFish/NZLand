
using AutoMapper;
using WNZland.Models.Domain;
using WNZland.Models.DTO;

namespace WNZland.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<Region, AddRegionRequestDto>().ReverseMap();
        CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();

        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();
    }

}
