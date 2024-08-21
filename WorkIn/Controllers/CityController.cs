using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Controllers;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.City;
using WorkIn.Domain.Sorts.City;
using WorkIn.Service.Contract;
using static WorkIn.Infrastructure.Dtos.City.CityDtos;

namespace Taskedin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService, IMapper mapper, IProfileService profileService) : base(mapper, profileService)
        {
            _cityService = cityService;
        }

        [HttpGet("Get-City")]
        public async Task<Response> GetCityAsync(int cityId)
        {
            try
            {
                if (cityId <= 0)
                    return new Response("Invalid city ID.", 400);

                var city = await _cityService.GetCityAsync(cityId);
                var cityDto = mapper.Map<CityDto>(city);
                return new Response(cityDto, "Success", true, 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpGet("Get-All-Cities")]
        public async Task<Response> GetAllCities([FromQuery] CityFilter filter, [FromQuery] CitySort sort)
        {
            try
            {

                var cities = await _cityService.GetAllCities(filter, sort);

                var cityDtos = mapper.Map<PagedModel<CityDto>>(cities);

                return new Response(cityDtos, "Success", true, 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }


        [HttpPost("Add-City")]
        public async Task<Response> CreateCityAsync([FromBody] CreateCityDto createCityDto)
        {
            if (createCityDto == null)
                return new Response("City data is null.", 400);

            try
            {
                var city = mapper.Map<City>(createCityDto);
                await _cityService.AddCityAsync(city);
                var cityDto = mapper.Map<CityDto>(city);
                return new Response(cityDto, "City created successfully.", true, 201)
                {
                    Data = new { id = city.Id }
                };
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpPut("Update-City")]
        public async Task<Response> UpdateCityAsync([FromBody] UpdateCityDto updateCityDto)
        {
            if (updateCityDto == null)
                return new Response("City data is null.", 400);

            try
            {
                var existingCity = await _cityService.GetCityAsync(updateCityDto.Id);
                if (existingCity == null)
                    return new Response("City not found.", 404);


                mapper.Map(updateCityDto, existingCity);
                await _cityService.UpdateCityAsync(existingCity);
                return new Response(null, "City updated successfully.", true, 204);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpDelete("Delete-City")]
        public async Task<Response> DeleteCityAsync(int cityId)
        {
            try
            {
                if (cityId <= 0)
                    return new Response("Invalid city ID.", 400);

                await _cityService.DeleteCityAsync(cityId);
                return new Response(null, "City deleted successfully.", true, 204);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, 404);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }
    }
}

