using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using static WorkIn.Infrastructure.Dtos.City.CityDtos;
using static WorkIn.Infrastructure.Dtos.Country.CountryDtos;
using static WorkIn.Infrastructure.Dtos.Profile.ProfileDtos;
using static WorkIn.Infrastructure.Dtos.Region.RegionDtos;

namespace WorkIn.Infrastructure.Mapping.MapProfile
{
    public class ProfileProfile : AutoMapper.Profile
    {

        public ProfileProfile()
        {
            CreateMap<Profile, ProfileDto>()
               .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
               .ReverseMap();

            CreateMap<CreateProfileDto, Profile>()
                .ReverseMap();

            CreateMap<UpdateProfileDto, Profile>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<Profile>, PagedModel<ProfileDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<PagedModel<ProfileDto>, ProfileDto>();

            CreateMap<Country, CountryDto>()
           .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Region, RegionDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

            CreateMap<City, CityDto>()
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<Profile, ProfileDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));


        }

    }
}
