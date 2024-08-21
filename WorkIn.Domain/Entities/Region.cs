namespace WorkIn.Domain.Entities
{
    public class Region : EntityBase
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
