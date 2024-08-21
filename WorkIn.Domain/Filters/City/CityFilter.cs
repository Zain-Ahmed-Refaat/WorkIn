namespace WorkIn.Domain.Filters.City
{
    public class CityFilter : FilterBase
    {
        public int? CityId { get; set; }

        public string ArName { get; set; }

        public string EnName { get; set; }

        public int? RegionId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
