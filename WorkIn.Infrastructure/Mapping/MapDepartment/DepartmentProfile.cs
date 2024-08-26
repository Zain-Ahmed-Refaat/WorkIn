using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using static WorkIn.Infrastructure.Dtos.Department.DepartmentDtos;

namespace WorkIn.Infrastructure.Mapping.MapDepartment
{
    public class DepartmentProfile : AutoMapper.Profile
    {

        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>()
               .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
               .ReverseMap();

            CreateMap<CreateDepartmentDto, Department>()
                .ReverseMap();

            CreateMap<UpdateDepartmentDto, Department>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<PagedModel<Department>, PagedModel<DepartmentDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<PagedModel<DepartmentDto>, DepartmentDto>();
        }

    }
}
