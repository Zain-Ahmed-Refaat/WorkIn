namespace WorkIn.Domain.Filters.Region
{
    public class RegionFilter : FilterBase
    {
        public string ArName { get; set; }
        public string EnName { get; set; }
        public int? CountryId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
