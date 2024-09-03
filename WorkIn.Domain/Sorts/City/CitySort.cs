namespace WorkIn.Domain.Sorts.City
{
    public class CitySort
    {
        public CitySortEnum orderKey { get; set; }

        public SortEnum orderDirection { get; set; }
    }

    public enum CitySortEnum
    {
        CityId,

        RegionId,

        ArName,

        EnName,
    }
}
