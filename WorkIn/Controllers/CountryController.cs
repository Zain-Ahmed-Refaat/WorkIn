using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Service.Contract;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService, IMapper mapper, IProfileService profileService) : base(mapper, profileService)
        {
            this.countryService = countryService;
        }


        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<Response> GetAll([FromQuery] int page, int limit, string search = "")
        {
            try
            {
                PagedModel<Country> allCountries = await countryService.GetAll(page, limit, search);
                return new Response(allCountries);
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
