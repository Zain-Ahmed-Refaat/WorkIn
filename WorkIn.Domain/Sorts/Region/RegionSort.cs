namespace WorkIn.Domain.Sorts.Region
{
    public class RegionSort
    {
        public RegionSortEnum orderKey { get; set; }

        public SortEnum orderDirection { get; set; }
    }

    public enum RegionSortEnum
    {
        ArName,
        EnName,
        CountryId
    }
}
