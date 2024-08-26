using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.JobTitle;
using WorkIn.Domain.Sorts.JobTitle;

namespace WorkIn.Service.Contract
{
    public interface IJobTitleService
    {
        Task AddJobTitleAsync(JobTitle jobTitle);
        Task<JobTitle> GetJobTitleAsync(int jobTitleId);
        Task<PagedModel<JobTitle>> GetAllJobTitlesNoFilter();
        Task<PagedModel<JobTitle>> GetAllJobTitles(JobTitleFilter filter, JobTitleSort sort);
        Task UpdateJobTitleAsync(JobTitle jobTitle);
        Task DeleteJobTitleAsync(int jobTitleId);
    }
}
