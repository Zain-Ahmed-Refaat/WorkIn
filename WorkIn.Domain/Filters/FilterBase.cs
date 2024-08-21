namespace WorkIn.Domain.Filters
{
    public class FilterBase
    {
        public int page { get; set; }
        public int limit { get; set; }
        public string search { get; set; } = "";
    }
}
