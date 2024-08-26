using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIn.Domain.Filters.WorkInfo
{
    public class WorkInfoFilter : FilterBase
    {
        public int? EmployeeId { get; set; }
        public int? ManagerId { get; set; }
        public int? JobTitleId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CountryId { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public DateTime? LastPromotionDateStart { get; set; }
        public DateTime? LastPromotionDateEnd { get; set; }
        public string? Skills { get; set; }
        public string? WorkEmail { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
