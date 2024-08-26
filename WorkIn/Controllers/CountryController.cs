using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Service.Contract;
using static WorkIn.Infrastructure.Dtos.Country.CountryDtos;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService, IMapper mapper) : base(mapper)
        {
            this.countryService = countryService;
        }


        [HttpPost("Add-Country")]
        public async Task<Response> CreateAsync([FromBody] CreateCountryDto createCountryDto)
        {
            if (createCountryDto == null)
                return new Response("Country data is null.", "Bad request", false, 400);

            try
            {
                var country = mapper.Map<Country>(createCountryDto);
                await countryService.AddCountryAsync(country);
                return new Response("Country created successfully.", 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpGet("Get-All-Countries")]
        public async Task<Response> GetAll([FromQuery] int page, int limit, string search = "")
        {
            try
            {
                var allCountries = await countryService.GetAll(page, limit, search);
                var countryDtos = mapper.Map<PagedModel<CountryDto>>(allCountries);

                return new Response(countryDtos, "Success", true, 200);
            }
            catch (Exception ex)
            {
                int code = 200;
                int.TryParse(ex.Data["Code"]?.ToString(), out code);
                return new Response(ex.Message, code)
                {
                    Errors = ex
                }; ;
            }
        }

    }
}
