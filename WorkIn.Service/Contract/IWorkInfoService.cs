using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.WorkInfo;
using WorkIn.Domain.Sorts.WorkInfo;

namespace WorkIn.Service.Contract
{
    public interface IWorkInfoService
    {
        Task<WorkInfo> GetWorkInfoAsync(int workInfoId);
        Task<PagedModel<WorkInfo>> GetAllWorkInfoAsync(WorkInfoFilter filter, WorkInfoSort sort);
        Task AddWorkInfoAsync(WorkInfo workInfo);
        Task UpdateWorkInfoAsync(WorkInfo workInfo);
        Task DeleteWorkInfoAsync(int workInfoId);
    }
}
