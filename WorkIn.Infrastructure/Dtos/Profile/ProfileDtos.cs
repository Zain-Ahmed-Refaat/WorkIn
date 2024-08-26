using static WorkIn.Infrastructure.Dtos.City.CityDtos;
using static WorkIn.Infrastructure.Dtos.Department.DepartmentDtos;

namespace WorkIn.Infrastructure.Dtos.Profile
{
    public class ProfileDtos
    {
        public class ProfileDto
        {
            public int Id { get; set; }
            public int? ManagerId { get; set; }
            public int DepartmentId { get; set; }
            public int CityId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string JobTitle { get; set; }
            public virtual ProfileDto? Manager { get; set; }
            public DepartmentDto Department { get; set; }
            public CityDto City { get; set; }
        }

        public class CreateProfileDto
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string JobTitle { get; set; }
            public int? ManagerId { get; set; }
            public int DepartmentId { get; set; }
            public int CityId { get; set; }
        }

        public class UpdateProfileDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public string? JobTitle { get; set; }
            public int? ManagerId { get; set; }
            public int? DepartmentId { get; set; }
            public int? CityId { get; set; }
        }
    }

}
