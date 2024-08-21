using WorkIn.Domain.Extensions;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.WorkInfo;
using WorkIn.Domain.Sorts.WorkInfo;
using WorkIn.Domain.Sorts;
using WorkIn.Persistence.Data;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;

namespace WorkIn.Service.Implementation
{
    public class WorkInfoService : IWorkInfoService
    {
        private readonly IRepository<WorkInfo> workInfoRepository;
        private readonly ApplicationDbContext context;

        public WorkInfoService(IRepository<WorkInfo> workInfoRepository, ApplicationDbContext context)
        {
            this.workInfoRepository = workInfoRepository;
            this.context = context;
        }

        public async Task<WorkInfo> GetWorkInfoAsync(int workInfoId)
        {
            if (workInfoId <= 0)
                throw new ArgumentException("Invalid WorkInfo ID", nameof(workInfoId));

            var workInfo = await workInfoRepository.GetAsync(workInfoId);
            if (workInfo == null)
                throw new KeyNotFoundException($"WorkInfo with ID {workInfoId} not found.");

            return workInfo;
        }

        public async Task<PagedModel<WorkInfo>> GetAllWorkInfoAsync(WorkInfoFilter filter, WorkInfoSort sort)
        {
            ValidateFilter(filter, sort);

            var query = context.WorkInfos.AsQueryable();
            query = query.Filter(filter);
            query = query.Sort(sort);
            query = query.Search(filter.search);

            var pagedModel = query.Paginate(filter.page, filter.limit);
            return pagedModel;
        }

        private void ValidateFilter(WorkInfoFilter filter, WorkInfoSort sort)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (sort == null)
                throw new ArgumentNullException(nameof(sort), "Sort cannot be null.");

            if (filter.page <= 0)
                filter.page = 1;

            if (filter.limit <= 0)
                filter.limit = 10;

            if (!Enum.IsDefined(typeof(WorkInfoSortEnum), sort.SortKey))
                throw new ArgumentException("Invalid sort key.", nameof(sort.SortKey));

            if (!Enum.IsDefined(typeof(SortEnum), sort.OrderDirection))
                throw new ArgumentException("Invalid sort direction.", nameof(sort.OrderDirection));
        }

        public async Task AddWorkInfoAsync(WorkInfo workInfo)
        {
            workInfo.ValidateWorkInfo();

            await workInfoRepository.InsertAsync(workInfo);
            await context.SaveChangesAsync();
        }

        public async Task UpdateWorkInfoAsync(WorkInfo workInfo)
        {
            workInfo.ValidateWorkInfoWithId();

            await workInfoRepository.UpdateAsync(workInfo);
            await context.SaveChangesAsync();
        }

        public async Task DeleteWorkInfoAsync(int workInfoId)
        {
            if (workInfoId <= 0)
                throw new ArgumentException("WorkInfo ID must be greater than zero", nameof(workInfoId));

            var existingWorkInfo = await workInfoRepository.GetAsync(workInfoId);
            if (existingWorkInfo == null)
                throw new KeyNotFoundException($"No WorkInfo found with ID {workInfoId}");

            await workInfoRepository.DeleteAsync(existingWorkInfo);
            await context.SaveChangesAsync();
        }
    }
}
