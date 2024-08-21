namespace WorkIn.Domain.Filters.Department
{
    public class DepartmentFilter : FilterBase
    {
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
