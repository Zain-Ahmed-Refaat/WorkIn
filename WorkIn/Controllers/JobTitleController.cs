using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.JobTitle;
using WorkIn.Domain.Sorts.JobTitle;
using WorkIn.Service.Contract;
using static WorkIn.Infrastructure.Dtos.JobTitle.JobTitleDtos;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : BaseController
    {
        private readonly IJobTitleService jobTitleService;

        public JobTitleController(IMapper mapper, IJobTitleService jobTitleService) : base(mapper)
        {
            this.jobTitleService = jobTitleService;
        }

        [HttpGet("Get-JobTitle")]
        public async Task<Response> GetByIdAsync(int id)
        {
            try
            {
                var jobTitle = await jobTitleService.GetJobTitleAsync(id);
                var jobTitleDto = mapper.Map<JobTitleDto>(jobTitle);

                return new Response(jobTitleDto, "Success", true, 200);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "JobTitle not found", false, 404);
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

        [HttpGet("Get-All-JobTitles-No-Filter")]
        public async Task<IActionResult> GetAllJobTitlesNoFilter()
        {
            try
            {
                var JobTitlesPagedModel = await jobTitleService.GetAllJobTitlesNoFilter();
                var JobTitlesDtos = mapper.Map<PagedModel<JobTitleDto>>(JobTitlesPagedModel);

                return Ok(new Response(JobTitlesDtos, "Success", true, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                });
            }
        }


        [HttpGet("Get-All-JobTitles")]
        public async Task<Response> GetAllJobTitles([FromQuery] JobTitleFilter filter, [FromQuery] JobTitleSort sort)
        {
            try
            {
                var JobTitlePagedModel = await jobTitleService.GetAllJobTitles(filter, sort);

                var JobTitleDtos = mapper.Map<PagedModel<JobTitleDto>>(JobTitlePagedModel);

                return new Response(JobTitleDtos, "Success", true, 200);
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

        [HttpPost("Add-JobTitle")]
        public async Task<Response> CreateAsync([FromBody] CreateJobTitleDto createJobTitleDto)
        {
            if (createJobTitleDto == null)
                return new Response("JobTitle data is null.", "Bad request", false, 400);

            try
            {
                var jobTitle = mapper.Map<JobTitle>(createJobTitleDto);
                await jobTitleService.AddJobTitleAsync(jobTitle);

                return new Response("JobTitle created successfully.", 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpPut("Update-JobTitle")]
        public async Task<Response> UpdateJobTitleAsync([FromBody] UpdateJobTitleDto updateJobTitleDto)
        {
            if (updateJobTitleDto == null)
                return new Response("JobTitle data is null.", 400);

            try
            {
                var existingJobTitle = await jobTitleService.GetJobTitleAsync(updateJobTitleDto.Id);
                if (existingJobTitle == null)
                    return new Response("JobTitle not found.", 404);


                mapper.Map(updateJobTitleDto, existingJobTitle);
                await jobTitleService.UpdateJobTitleAsync(existingJobTitle);

                return new Response("JobTitle updated successfully.", 204);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "JobTitle not found", false, 404);
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

        [HttpDelete("Delete-JobTitle")]
        public async Task<Response> DeleteAsync(int id)
        {
            try
            {
                await jobTitleService.DeleteJobTitleAsync(id);
                return new Response("JobTitle deleted successfully.", 200);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "JobTitle not found", false, 404);
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
