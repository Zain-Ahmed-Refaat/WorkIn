using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Department;
using WorkIn.Domain.Sorts.Department;
using WorkIn.Domain.Sorts;

namespace WorkIn.Domain.Extensions
{
    public static class DepartmentExtensions
    {

        public static void ValidateDepartment(this Department department)
        {
            if (department == null)
                throw new ArgumentException(nameof(department), "Department cannot be null");

            if (string.IsNullOrWhiteSpace(department.Name))
                throw new ArgumentException("Department name is required", nameof(department.Name));
        }

        public static void ValidateDepartmentWithId(this Department department)
        {
            if (department == null)
                throw new ArgumentException(nameof(department), "Department cannot be null");

            if (department.Id == 0)
                throw new ArgumentException(nameof(department), "DepartmentId cannot be zero or null");

            if (string.IsNullOrWhiteSpace(department.Name))
                throw new ArgumentException("Department name is required", nameof(department.Name));

        }

        // Filtering Departments
        public static IQueryable<Department> Filter(this IQueryable<Department> departments, DepartmentFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (filter.DepartmentId.HasValue)
                departments = departments.Where(d => d.Id == filter.DepartmentId.Value);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                departments = departments.Where(d => d.Name.Contains(filter.Name));

            if (filter.ManagerId.HasValue)
                departments = departments.Where(d => d.ManagerId == filter.ManagerId.Value);

            if (filter.IsDeleted.HasValue)
                departments = departments.Where(d => d.IsDeleted == filter.IsDeleted.Value);

            return departments;
        }

        // Sorting Departments
        public static IQueryable<Department> Sort(this IQueryable<Department> departments, DepartmentSort sort)
        {
            IOrderedQueryable<Department> orderedDepartments;

            switch (sort.orderKey)
            {
                case DepartmentSortEnum.Name:
                    orderedDepartments = sort.orderDirection == SortEnum.OrderBy
                        ? departments.OrderBy(d => d.Name)
                        : departments.OrderByDescending(d => d.Name);
                    break;

                case DepartmentSortEnum.CreationDateAsc:
                    orderedDepartments = sort.orderDirection == SortEnum.OrderBy
                        ? departments.OrderBy(d => d.CreationDate)
                        : departments.OrderByDescending(d => d.CreationDate);
                    break;

                case DepartmentSortEnum.ManagerId:
                    orderedDepartments = sort.orderDirection == SortEnum.OrderBy
                        ? departments.OrderBy(d => d.ManagerId)
                        : departments.OrderByDescending(d => d.ManagerId);
                    break;

                default:
                    orderedDepartments = departments.OrderByDescending(d => d.Id);
                    break;
            }

            return orderedDepartments;
        }

        public static IQueryable<Department> Search(this IQueryable<Department> departments, string search)
        {
            if (string.IsNullOrEmpty(search))
                return departments;

            return departments.Where(d => d.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                                        || d.ManagerId.ToString().Contains(search)
                                        || (d.CreationDate.HasValue && d.CreationDate.Value
                                        .ToString("yyyy-MM-dd").Contains(search)));
        }

    }
}
