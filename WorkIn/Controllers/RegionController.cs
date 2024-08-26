using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Region;
using WorkIn.Domain.Sorts.Region;
using WorkIn.Service.Contract;
using static WorkIn.Infrastructure.Dtos.Region.RegionDtos;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : BaseController
    {
        private readonly IRegionService regionService;

        public RegionController(IRegionService regionService, IMapper mapper) : base(mapper)
        {
            this.regionService = regionService;
        }

        [HttpGet("Get-Region")]
        public async Task<Response> GetByIdAsync(int id)
        {
            try
            {
                var region = await regionService.GetRegionAsync(id);
                var regionDto = mapper.Map<RegionDto>(region);
                return new Response(regionDto, "Success", true, 200);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "Region not found", false, 404);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, "Invalid request", false, 400);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpGet("Get-All-Regions-No-Filter")]
        public async Task<IActionResult> GetAllRegionsNoFilter()
        {
            try
            {
                var regionsPagedModel = await regionService.GetAllRegionsNoFilter();
                var regionDtos = mapper.Map<PagedModel<RegionDto>>(regionsPagedModel);

                return Ok(new Response(regionDtos, "Success", true, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                });
            }
        }


        [HttpGet("Get-All-Regions")]
        public async Task<Response> GetAllRegions([FromQuery] RegionFilter filter, [FromQuery] RegionSort sort)
        {
            try
            {
                var regionsPagedModel = await regionService.GetAllRegions(filter, sort);

                var regionDtos = mapper.Map<PagedModel<RegionDto>>(regionsPagedModel);

                return new Response(regionDtos, "Success", true, 200);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, "Invalid request", false, 400);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }


        [HttpPost("Add-Region")]
        public async Task<Response> CreateAsync([FromBody] CreateRegionDto regionCreateDto)
        {
            if (regionCreateDto == null)
                return new Response("Region data is null.", "Bad request", false, 400);

            try
            {
                var region = mapper.Map<Region>(regionCreateDto);
                await regionService.AddRegionAsync(region);
                return new Response(region, "Region created successfully.", true, 201);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpPut("Update-Region")]
        public async Task<Response> UpdateAsync(int id, [FromBody] UpdateRegionDto regionUpdateDto)
        {
            if (regionUpdateDto == null)
                return new Response("Region data is null.", "Bad request", false, 400);

            try
            {
                var existingRegion = await regionService.GetRegionAsync(id);
                if (existingRegion == null)
                    return new Response("Region not found.", "Not found", false, 404);

                mapper.Map(regionUpdateDto, existingRegion);
                await regionService.UpdateRegionAsync(existingRegion);

                return new Response(existingRegion, "Region updated successfully.", true, 200);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "Region not found", false, 404);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, "Invalid request", false, 400);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpDelete("Delete-Region")]
        public async Task<Response> DeleteAsync(int id)
        {
            try
            {
                await regionService.DeleteRegionAsync(id);
                return new Response(null, "Region deleted successfully.", true, 204);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "Region not found", false, 404);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, "Invalid request", false, 400);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }
    }
}
