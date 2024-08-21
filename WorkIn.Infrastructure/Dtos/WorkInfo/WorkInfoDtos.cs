using WorkIn.Domain.Entities;

namespace WorkIn.Infrastructure.Dtos.WorkInfo
{

    public class WorkInfoDtos
    {

        public class WorkInfoDto : UpdateWorkInfoDto
        {
            
            public Profile Employee { get; set; }
            public Profile Manager { get; set; }
            public JobTitle JobTitle { get; set; }
            public Domain.Entities.Department Department { get; set; }
            public Country Country { get; set; }
            public Domain.Entities.Region Region { get; set; }
            public Domain.Entities.City City { get; set; }

        }

        public class CreateWorkInfoDto
        {
            public int EmployeeId { get; set; }
            public int ManagerId { get; set; }
            public int JobTitleId { get; set; }
            public int DepartmentId { get; set; }
            public int CountryId { get; set; }
            public int RegionId { get; set; }
            public int CityId { get; set; }
            public decimal Salary { get; set; }
            public decimal Bouns { get; set; }
            public DateTime LastPromotionDate { get; set; }
            public string WorkEmail { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class UpdateWorkInfoDto : CreateWorkInfoDto
        {
            public int Id { get; set; }
        }
    }
}
