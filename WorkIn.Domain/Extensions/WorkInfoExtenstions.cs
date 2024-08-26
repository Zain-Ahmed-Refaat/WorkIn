using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.WorkInfo;
using WorkIn.Domain.Sorts.WorkInfo;
using WorkIn.Domain.Sorts;

namespace WorkIn.Domain.Extensions
{
    public static class WorkInfoExtensions
    {
        public static void ValidateWorkInfo(this WorkInfo workInfo)
        {
            if (workInfo == null)
                throw new ArgumentException(nameof(workInfo), "WorkInfo cannot be null");

            if (workInfo.EmployeeId <= 0)
                throw new ArgumentException("EmployeeId must be greater than zero",
                    nameof(workInfo.EmployeeId));

            if (workInfo.ManagerId <= 0)
                throw new ArgumentException("ManagerId must be greater than zero",
                    nameof(workInfo.ManagerId));

            if (workInfo.JobTitleId <= 0)
                throw new ArgumentException("JobTitleId must be greater than zero",
                    nameof(workInfo.JobTitleId));

            if (workInfo.DepartmentId <= 0)
                throw new ArgumentException("DepartmentId must be greater than zero",
                    nameof(workInfo.DepartmentId));

            if (workInfo.CityId <= 0)
                throw new ArgumentException("CityId must be greater than zero",
                    nameof(workInfo.CityId));

            if (workInfo.Salary <= 0)
                throw new ArgumentException("Salary must be greater than zero",
                    nameof(workInfo.Salary));
        }

        public static void ValidateWorkInfoWithId(this WorkInfo workInfo)
        {
            if (workInfo == null)
                throw new ArgumentException(nameof(workInfo), "WorkInfo cannot be null");

            if (workInfo.Id <= 0)
                throw new ArgumentException(nameof(workInfo.Id), "WorkInfo Id Is Wrong");

            if (workInfo.EmployeeId <= 0)
                throw new ArgumentException("EmployeeId must be greater than zero",
                    nameof(workInfo.EmployeeId));

            if (workInfo.ManagerId <= 0)
                throw new ArgumentException("ManagerId must be greater than zero",
                    nameof(workInfo.ManagerId));

            if (workInfo.JobTitleId <= 0)
                throw new ArgumentException("JobTitleId must be greater than zero",
                    nameof(workInfo.JobTitleId));

            if (workInfo.DepartmentId <= 0)
                throw new ArgumentException("DepartmentId must be greater than zero",
                    nameof(workInfo.DepartmentId));

            if (workInfo.CityId <= 0)
                throw new ArgumentException("CityId must be greater than zero",
                    nameof(workInfo.CityId));

            if (workInfo.Salary <= 0)
                throw new ArgumentException("Salary must be greater than zero",
                    nameof(workInfo.Salary));
        }

        public static IQueryable<WorkInfo> Filter(this IQueryable<WorkInfo> workInfos, WorkInfoFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (filter.EmployeeId.HasValue)
                workInfos = workInfos.Where(w => w.EmployeeId == filter.EmployeeId.Value);

            if (filter.ManagerId.HasValue)
                workInfos = workInfos.Where(w => w.ManagerId == filter.ManagerId.Value);

            if (filter.JobTitleId.HasValue)
                workInfos = workInfos.Where(w => w.JobTitleId == filter.JobTitleId.Value);

            if (filter.DepartmentId.HasValue)
                workInfos = workInfos.Where(w => w.DepartmentId == filter.DepartmentId.Value);

            if (filter.CountryId.HasValue)
                workInfos = workInfos.Where(w => w.City.Region.CountryId == filter.CountryId.Value);

            if (filter.RegionId.HasValue)
                workInfos = workInfos.Where(w => w.City.RegionId == filter.RegionId.Value);

            if (filter.CityId.HasValue)
                workInfos = workInfos.Where(w => w.CityId == filter.CityId.Value);

            if (filter.SalaryMin.HasValue)
                workInfos = workInfos.Where(w => w.Salary >= filter.SalaryMin.Value);

            if (filter.SalaryMax.HasValue)
                workInfos = workInfos.Where(w => w.Salary <= filter.SalaryMax.Value);

            return workInfos;
        }


        public static IQueryable<WorkInfo> Sort(this IQueryable<WorkInfo> workInfos, WorkInfoSort sort)
        {
            if (sort == null)
                throw new ArgumentNullException(nameof(sort));

            IOrderedQueryable<WorkInfo> orderedWorkInfos;

            switch (sort.SortKey)
            {
                case WorkInfoSortEnum.EmployeeId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.EmployeeId)
                        : workInfos.OrderByDescending(w => w.EmployeeId);
                    break;

                case WorkInfoSortEnum.ManagerId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.ManagerId)
                        : workInfos.OrderByDescending(w => w.ManagerId);
                    break;

                case WorkInfoSortEnum.JobTitleId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.JobTitleId)
                        : workInfos.OrderByDescending(w => w.JobTitleId);
                    break;

                case WorkInfoSortEnum.DepartmentId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.DepartmentId)
                        : workInfos.OrderByDescending(w => w.DepartmentId);
                    break;

                case WorkInfoSortEnum.CountryId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.City.Region.CountryId)
                        : workInfos.OrderByDescending(w => w.City.Region.CountryId);
                    break;

                case WorkInfoSortEnum.RegionId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.City.RegionId)
                        : workInfos.OrderByDescending(w => w.City.RegionId);
                    break;

                case WorkInfoSortEnum.CityId:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.CityId)
                        : workInfos.OrderByDescending(w => w.CityId);
                    break;

                case WorkInfoSortEnum.Salary:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.Salary)
                        : workInfos.OrderByDescending(w => w.Salary);
                    break;

                case WorkInfoSortEnum.CreationDate:
                    orderedWorkInfos = sort.OrderDirection == SortEnum.OrderBy
                        ? workInfos.OrderBy(w => w.CreationDate)
                        : workInfos.OrderByDescending(w => w.CreationDate);
                    break;

                default:
                    orderedWorkInfos = workInfos.OrderByDescending(w => w.CreationDate);
                    break;
            }

            return orderedWorkInfos;
        }

        public static IQueryable<WorkInfo> Search(this IQueryable<WorkInfo> workInfos, string search)
        {
            if (string.IsNullOrEmpty(search))
                return workInfos;

            return workInfos
                .AsEnumerable()
                .Where(w => 
                       w.Salary.ToString().Contains(search)
                    || w.CityId.ToString().Contains(search)
                    || w.ManagerId.ToString().Contains(search)
                    || w.EmployeeId.ToString().Contains(search)
                    || w.JobTitleId.ToString().Contains(search)
                    || w.DepartmentId.ToString().Contains(search))
                .AsQueryable();
        }
    }
}
