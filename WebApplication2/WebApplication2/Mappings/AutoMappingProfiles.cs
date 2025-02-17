using AutoMapper;
using NZWalks.API.Models.Domain;
using WebApplication1.Models.Domain;
using WebApplication2.Models.Domain.DTO;

namespace WebApplication2.Mappings
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles() {

            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkReqDTO,Walk>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
            CreateMap<Difficulty,DifficultyDTO>().ReverseMap();
            CreateMap<Walk, UpdateDTO>().ReverseMap();



        }
    }
}
