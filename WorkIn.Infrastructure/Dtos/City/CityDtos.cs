using static WorkIn.Infrastructure.Dtos.Region.RegionDtos;

namespace WorkIn.Infrastructure.Dtos.City
{
    public class CityDtos
    {
        public class CityDto 
        {
            public int Id { get; set; }
            public string ArName { get; set; }
            public string EnName { get; set; }

            public int RegionId { get; set; }
            public RegionDto Region { get; set; }
        }

        public class CreateCityDto
        {
            public string ArName { get; set; }
            public string EnName { get; set; }

            public int RegionId { get; set; }
        }

        public class UpdateCityDto
        { 
            public int Id { get; set; }
            public string ArName { get; set; }
            public string EnName { get; set; }

            public int RegionId { get; set; }

        }

    }
}
