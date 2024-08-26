using static WorkIn.Infrastructure.Dtos.WorkInfo.WorkInfoDtos;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;

namespace WorkIn.Infrastructure.Mapping.MapWorkInfo
{
    public class WorkInfoProfile : AutoMapper.Profile
    {
        public WorkInfoProfile()
        {
            CreateMap<WorkInfo, WorkInfoDto>()
               .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
               .ReverseMap();

            CreateMap<CreateWorkInfoDto, WorkInfo>()
                .ReverseMap();

            CreateMap<UpdateWorkInfoDto, WorkInfo>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<WorkInfo>, PagedModel<WorkInfoDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<PagedModel<WorkInfoDto>, WorkInfoDto>();
        }
    }
}
