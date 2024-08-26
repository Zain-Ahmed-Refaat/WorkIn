using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.JobTitle;
using WorkIn.Domain.Sorts.JobTitle;
using WorkIn.Domain.Sorts;

namespace WorkIn.Domain.Extensions
{
    public static class JobTitleExtensions
    {

        public static void ValidateJobTitle(this JobTitle jobTitle)
        {
            if(jobTitle.Title == null)
                throw new ArgumentNullException(nameof(jobTitle.Title), "Cannot Be Null");
        }
        public static void ValidateJobTitle(this JobTitle jobTitle, int id)
        {
            if (jobTitle.Title == null)
                throw new ArgumentNullException(nameof(jobTitle.Title), "Cannot Be Null");

            if (id == null)
                throw new ArgumentNullException(nameof(jobTitle.Id), "Cannot Be Null");
        }

        public static IQueryable<JobTitle> Filter(this IQueryable<JobTitle> jobTitles, JobTitleFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (filter.Id.HasValue)
                jobTitles = jobTitles.Where(j => j.Id == filter.Id.Value);

            if (!string.IsNullOrWhiteSpace(filter.Title))
                jobTitles = jobTitles.Where(j => j.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase));

            return jobTitles;
        }

        public static IQueryable<JobTitle> Sort(this IQueryable<JobTitle> jobTitles, JobTitleSort sort)
        {
            if (sort == null)
                throw new ArgumentNullException(nameof(sort));

            IOrderedQueryable<JobTitle> orderedJobTitles;

            switch (sort.OrderKey)
            {
                case JobTitleSortEnum.Title:
                    orderedJobTitles = sort.OrderDirection == SortEnum.OrderBy
                        ? jobTitles.OrderBy(j => j.Title)
                        : jobTitles.OrderByDescending(j => j.Title);
                    break;

                default:
                    orderedJobTitles = sort.OrderDirection == SortEnum.OrderBy
                        ? jobTitles.OrderBy(j => j.Id)
                        : jobTitles.OrderByDescending(j => j.Id);
                    break;
            }

            return orderedJobTitles;
        }

        public static IQueryable<JobTitle> Search(this IQueryable<JobTitle> jobTitles, string search)
        {
            if (string.IsNullOrEmpty(search))
                return jobTitles;

            return jobTitles
                .AsEnumerable()
                .Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || (c.CreationDate.HasValue && c.CreationDate.Value.ToString("yyyy-MM-dd").Contains(search)))
                .AsQueryable();
        }

    }
}
