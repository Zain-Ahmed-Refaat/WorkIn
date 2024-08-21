namespace WorkIn.Domain.Entities
{
    public class City : Country
    {
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
