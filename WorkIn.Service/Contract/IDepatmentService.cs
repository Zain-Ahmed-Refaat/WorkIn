using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Department;
using WorkIn.Domain.Sorts.Department;

namespace WorkIn.Service.Contract
{
    public interface IDepartmentService
    {
        Task AddDepartmentAsync(Department department);

        Task<Department> GetDepartmentAsync(int departmentId);

        Task<PagedModel<Department>> GetAllDepartments(DepartmentFilter filter, DepartmentSort sort);

        Task UpdateDepartmentAsync(Department department);

        Task DeleteDepartmentAsync(int departmentId);

    }
}
