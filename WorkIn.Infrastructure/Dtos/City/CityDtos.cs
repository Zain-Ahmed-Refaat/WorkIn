namespace WorkIn.Infrastructure.Dtos.City
{
    public class CityDtos
    {
        public class CityDto : UpdateCityDto
        {
            public Domain.Entities.Region Region { get; set; }
        }

        public class CreateCityDto
        {
            public string ArName { get; set; }
            public string EnName { get; set; }

            public int RegionId { get; set; }
        }

        public class UpdateCityDto : CreateCityDto
        {
            public int Id { get; set; }

        }

    }
}
