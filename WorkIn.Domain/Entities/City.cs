namespace WorkIn.Domain.Entities
{
    public class City : EntityBase
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
