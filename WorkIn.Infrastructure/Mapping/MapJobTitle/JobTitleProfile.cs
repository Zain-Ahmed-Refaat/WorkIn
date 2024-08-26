using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using static WorkIn.Infrastructure.Dtos.JobTitle.JobTitleDtos;

namespace WorkIn.Infrastructure.Mapping.MapJobTitle
{
    public class JobTitleProfile : AutoMapper.Profile
    {

        public JobTitleProfile()
        {
            CreateMap<JobTitle, JobTitleDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<CreateJobTitleDto, JobTitle>()
                .ReverseMap();

            CreateMap<UpdateJobTitleDto, JobTitle>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<JobTitle>, PagedModel<JobTitleDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<PagedModel<JobTitleDto>, JobTitleDto>();
        }

    }
}
