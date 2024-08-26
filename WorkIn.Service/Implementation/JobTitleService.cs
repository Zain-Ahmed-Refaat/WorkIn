using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Sorts;
using WorkIn.Service.Contract;
using WorkIn.Persistence.Data;
using WorkIn.Persistence.MainRepository;
using WorkIn.Domain.Filters.JobTitle;
using WorkIn.Domain.Sorts.JobTitle;
using WorkIn.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace WorkIn.Service.Implementation
{
    public class JobTitleService : IJobTitleService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<JobTitle> jobTitleRepository;

        public JobTitleService(ApplicationDbContext context, IRepository<JobTitle> jobTitleRepository)
        {
            this.context = context;
            this.jobTitleRepository = jobTitleRepository;
        }

        public async Task AddJobTitleAsync(JobTitle jobTitle)
        {
            jobTitle.ValidateJobTitle();

            var existingJobTitle = await context.JobTitles
                .FirstOrDefaultAsync(x => x.Title == jobTitle.Title);
            if (existingJobTitle != null)
                throw new ArgumentException($"JobTitle with name {jobTitle.Title} Already Exists");

            await jobTitleRepository.InsertAsync(jobTitle);
            await context.SaveChangesAsync();
        }

        public async Task<JobTitle> GetJobTitleAsync(int jobTitleId)
        {
            if (jobTitleId <= 0)
                throw new ArgumentException("Invalid JobTitle ID", nameof(jobTitleId));

            var JobTitle = await jobTitleRepository.GetAsync(jobTitleId);
            if (JobTitle == null)
                throw new KeyNotFoundException($"JobTitle with ID {jobTitleId} not found.");

            return JobTitle;
        }

        public async Task<PagedModel<JobTitle>> GetAllJobTitlesNoFilter()
        {
            var query = context.JobTitles.AsQueryable();
            var pagedModel = query.Paginate(1, 10);
            return pagedModel;
        }


        public async Task<PagedModel<JobTitle>> GetAllJobTitles(JobTitleFilter filter, JobTitleSort sort)
        {
            ValidateFilter(filter, sort);

            var query = context.JobTitles.AsQueryable();
            query = query.Filter(filter);
            query = query.Sort(sort);
            query = query.Search(filter.search);

            var pagedModel = query.Paginate(filter.page, filter.limit);
            return pagedModel;
        }

        private void ValidateFilter(JobTitleFilter filter, JobTitleSort sort)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (sort == null)
                throw new ArgumentNullException(nameof(sort), "Sort cannot be null.");

            if (filter.page <= 0)
                filter.page = 1;

            if (filter.limit <= 0)
                filter.limit = 10;

            if (!Enum.IsDefined(typeof(JobTitleSortEnum), sort.OrderKey))
                throw new ArgumentException("Invalid sort key.", nameof(sort.OrderKey));

            if (!Enum.IsDefined(typeof(SortEnum), sort.OrderDirection))
                throw new ArgumentException("Invalid sort direction.", nameof(sort.OrderDirection));
        }

        public async Task UpdateJobTitleAsync(JobTitle jobTitle)
        {
            jobTitle.ValidateJobTitle(jobTitle.Id);

            await jobTitleRepository.UpdateAsync(jobTitle);
            await context.SaveChangesAsync();
        }

        public async Task DeleteJobTitleAsync(int jobTitleId)
        {
            if (jobTitleId <= 0)
                throw new ArgumentException("JobTitle Id must be greater than zero", nameof(jobTitleId));

            var existingJobTitle = await jobTitleRepository.GetAsync(jobTitleId);
            if (existingJobTitle == null)
                throw new KeyNotFoundException($"No JobTitle found with ID {jobTitleId}");

            await jobTitleRepository.DeleteAsync(existingJobTitle);
        }
    }
}
