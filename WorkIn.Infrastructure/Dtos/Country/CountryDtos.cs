namespace WorkIn.Infrastructure.Dtos.Country
{
    public class CountryDtos
    {
        public class CreateCountryDto
        {
            public string ArName { get; set; }
            public string EnName { get; set; }
        } 

        public class UpdateCountryDto
        {
            public int Id { get; set; }
            public string ArName { get; set; }
            public string EnName { get; set; }
        }
        
        public class CountryDto
        {
            public int Id { get; set; }
            public string ArName { get; set; }
            public string EnName { get; set; }
        }


    }
}
