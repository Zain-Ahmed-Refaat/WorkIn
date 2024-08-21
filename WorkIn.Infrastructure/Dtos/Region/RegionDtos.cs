using WorkIn.Domain.Entities;

namespace WorkIn.Infrastructure.Dtos.Region
{
    public class RegionDtos
    {
        public class RegionDto : UpdateRegionDto
        {
            public Country Country { get; set; }
        }

        public class CreateRegionDto
        {
            public string ArName { get; set; }
            public string EnName { get; set; }
            public int CountryId { get; set; }
        }
        public class UpdateRegionDto : CreateRegionDto
        {
            public int Id { get; set; }
        }

    }
}
