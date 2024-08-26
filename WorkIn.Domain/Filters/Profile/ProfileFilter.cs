using System.ComponentModel.DataAnnotations;

namespace WorkIn.Domain.Filters.Profile
{
    public class ProfileFilter : FilterBase
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CityId { get; set; }
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }

}
