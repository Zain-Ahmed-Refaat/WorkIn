namespace WorkIn.Domain.Sorts.ProfileSort
{
    public class ProfileSort
    {
        public ProfileSortEnum OrderKey { get; set; }
        public SortEnum OrderDirection { get; set; }
    }

    public enum ProfileSortEnum
    {
        Id,
        Name,
        JobTitle,
        DepartmentId,
        CityId,
        ManagerId
    }

}
