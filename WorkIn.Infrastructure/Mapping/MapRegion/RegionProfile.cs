using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using static WorkIn.Infrastructure.Dtos.Region.RegionDtos;

namespace WorkIn.Infrastructure.Mapping.MapRegion
{
    public class RegionProfile : AutoMapper.Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>()
               .ReverseMap();

            CreateMap<CreateRegionDto, Region>()
                .ReverseMap();

            CreateMap<UpdateRegionDto, Region>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<Region>, PagedModel<RegionDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<PagedModel<RegionDto>, RegionDto>();

        }
    }
}
