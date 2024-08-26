using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using static WorkIn.Infrastructure.Dtos.Country.CountryDtos;

namespace WorkIn.Infrastructure.Mapping.MapCountry
{
    public class CountryProfile : AutoMapper.Profile
    {
        public CountryProfile()
        {

            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<CreateCountryDto, Country>()
                .ReverseMap();

            CreateMap<UpdateCountryDto, Country>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<Country>, PagedModel<CountryDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<PagedModel<CountryDto>, CountryDto>();

        }
    }
}
