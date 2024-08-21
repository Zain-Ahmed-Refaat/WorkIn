namespace WorkIn.Domain.Sorts.Department
{
    public class DepartmentSort
    {
        public DepartmentSortEnum orderKey { get; set; }
        public SortEnum orderDirection { get; set; }
    }

    public enum DepartmentSortEnum
    {
        Name,
        CreationDateAsc,
        ManagerId
    }

}
