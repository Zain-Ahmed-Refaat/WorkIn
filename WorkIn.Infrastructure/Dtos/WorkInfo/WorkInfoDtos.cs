using static WorkIn.Infrastructure.Dtos.Profile.ProfileDtos;
using static WorkIn.Infrastructure.Dtos.JobTitle.JobTitleDtos;
using static WorkIn.Infrastructure.Dtos.Department.DepartmentDtos;
using static WorkIn.Infrastructure.Dtos.City.CityDtos;

namespace WorkIn.Infrastructure.Dtos.WorkInfo
{

    public class WorkInfoDtos
    {
        public class WorkInfoDto
        {
            public int Id { get; set; }
            public int EmployeeId { get; set; }
            public int ManagerId { get; set; }
            public int JobTitleId { get; set; }
            public int DepartmentId { get; set; }
            public int CityId { get; set; }
            public decimal Salary { get; set; }
            public ProfileDto Employee { get; set; }
            public ProfileDto Manager { get; set; }
            public JobTitleDto JobTitle { get; set; }
            public DepartmentDto Department { get; set; }
            public CityDto City { get; set; }

        }

        public class CreateWorkInfoDto
        {
            public int? EmployeeId { get; set; }
            public int? ManagerId { get; set; }
            public int? JobTitleId { get; set; }
            public int? DepartmentId { get; set; }
            public int? CityId { get; set; }
            public decimal? Salary { get; set; }
        }

        public class UpdateWorkInfoDto
        {
            public int Id { get; set; }
            public int? EmployeeId { get; set; }
            public int? ManagerId { get; set; }
            public int? JobTitleId { get; set; }
            public int? DepartmentId { get; set; }
            public int? CityId { get; set; }
            public decimal? Salary { get; set; }
        }
    }
}
