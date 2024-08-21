using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIn.Domain.Sorts.WorkInfo
{
    public class WorkInfoSort
    {
        public WorkInfoSortEnum SortKey { get; set; }
        public SortEnum OrderDirection { get; set; }
    }

    public enum WorkInfoSortEnum
    {
        EmployeeId,
        ManagerId,
        JobTitleId,
        DepartmentId,
        CountryId,
        RegionId,
        CityId,
        Salary,
        LastPromotionDate,
        WorkEmail,
        PhoneNumber,
        CreationDate
    }
}
