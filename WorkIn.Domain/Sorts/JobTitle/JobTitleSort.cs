namespace WorkIn.Domain.Sorts.JobTitle
{
    public class JobTitleSort
    {
        public JobTitleSortEnum OrderKey { get; set; }
        public SortEnum OrderDirection { get; set; }
    }

    public enum JobTitleSortEnum
    {
        Id,
        Title
    }

}
