using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Sorts;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;
using WorkIn.Persistence.Data;
using WorkIn.Domain.Extensions;
using WorkIn.Domain.Filters.Department;
using WorkIn.Domain.Sorts.Department;

namespace WorkIn.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IRepository<Profile> profileRepository;
        private readonly ApplicationDbContext context;

        public DepartmentService(ApplicationDbContext context, IRepository<Department> departmentRepository, IRepository<Profile> profileRepository)
        {
            this.context = context;
            this.departmentRepository = departmentRepository;
            this.profileRepository = profileRepository;
        }


        public async Task AddDepartmentAsync(Department department)
        {
            department.ValidateDepartment();

            await departmentRepository.InsertAsync(department);
            await context.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentAsync(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("Invalid Department ID", nameof(departmentId));

            var department = await departmentRepository.GetAsync(departmentId);
            if (department == null)
                throw new KeyNotFoundException($"Department with ID {departmentId} not found.");

            return department;
        }

        public async Task<PagedModel<Department>> GetAllDepartments(DepartmentFilter filter, DepartmentSort sort)
        {
            ValidateFilter(filter, sort);

            var query = context.Departments.AsQueryable();
            query = query.Filter(filter);
            query = query.Sort(sort);
            query = query.Search(filter.search);

            var pagedModel = query.Paginate(filter.page, filter.limit);
            return pagedModel;
        }

        private void ValidateFilter(DepartmentFilter filter, DepartmentSort sort)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (sort == null)
                throw new ArgumentNullException(nameof(sort), "Sort cannot be null.");

            if (filter.page <= 0)
                filter.page = 1;

            if (filter.limit <= 0)
                filter.limit = 10;

            if (!Enum.IsDefined(typeof(DepartmentSortEnum), sort.orderKey))
                throw new ArgumentException("Invalid sort key.", nameof(sort.orderKey));

            if (!Enum.IsDefined(typeof(SortEnum), sort.orderDirection))
                throw new ArgumentException("Invalid sort direction.", nameof(sort.orderDirection));
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            department.ValidateDepartmentWithId();

            await departmentRepository.UpdateAsync(department);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("DepartmentId must be greater than zero", nameof(departmentId));

            var existingdepartment = await departmentRepository.GetAsync(departmentId);
            if (existingdepartment == null)
                throw new KeyNotFoundException($"No Department found with ID {departmentId}");

            await departmentRepository.DeleteAsync(existingdepartment);
        }

    }
}
