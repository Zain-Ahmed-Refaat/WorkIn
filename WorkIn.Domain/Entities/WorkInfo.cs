using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkIn.Domain.Entities
{
    public class WorkInfo : EntityBase
    {
        public int EmployeeId { get; set; }
        public Profile Employee { get; set; }

        public int ManagerId { get; set; }
        public Profile Manager { get; set; }

        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Bonus { get; set; }

        public DateTime? LastPromotionDate { get; set; }

        public string Skills { get; set; }

        [MaxLength(100)]
        public string WorkEmail { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
