using static WorkIn.Infrastructure.Dtos.City.CityDtos;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Common;

namespace WorkIn.Infrastructure.Mapping.MapCity
{
    public class CityProfile : AutoMapper.Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<CreateCityDto, City>()
                .ReverseMap();

            CreateMap<UpdateCityDto, City>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<CityDto>, CityDto>();

        }
    }
}
