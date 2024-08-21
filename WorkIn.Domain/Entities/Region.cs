namespace WorkIn.Domain.Entities
{
    public class Region : Country
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
