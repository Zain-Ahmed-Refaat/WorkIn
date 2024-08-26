using static WorkIn.Infrastructure.Dtos.Country.CountryDtos;


namespace WorkIn.Infrastructure.Dtos.Region
{
    public class RegionDtos
    {
        public class RegionDto
        {
            public int Id { get; set; }
            public string ArName { get; set; }
            public string EnName { get; set; }
            public int CountryId { get; set; }
            public CountryDto Country { get; set; }
        }

        public class CreateRegionDto
        {
            public string ArName { get; set; }
            public string EnName { get; set; }
            public int CountryId { get; set; }
        }
        public class UpdateRegionDto
        { 
            public int Id { get; set; }
            public string ArName { get; set; }
            public string EnName { get; set; }
            public int CountryId { get; set; }
        }

    }
}
