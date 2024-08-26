using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.WorkInfo;
using WorkIn.Domain.Sorts.WorkInfo;
using WorkIn.Service.Contract;
using static WorkIn.Infrastructure.Dtos.WorkInfo.WorkInfoDtos;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkInfoController : BaseController
    {
        private readonly IWorkInfoService workService;

        public WorkInfoController(IWorkInfoService workService, IMapper mapper) : base(mapper)
        {
            this.workService = workService;
        }

        [HttpGet("Get-WorkInfo")]
        public async Task<Response> GetWorkInfo(int id)
        {
            try
            {
                if (id <= 0)
                    return new Response("Invalid WorkInfo ID provided");

                var workInfo = await workService.GetWorkInfoAsync(id);
                if (workInfo == null)
                    return new Response("WorkInfo not found");

                var workInfoDto = mapper.Map<WorkInfoDto>(workInfo);
                return new Response(workInfoDto);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, 400);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, 404);
            }
            catch (Exception ex)
            {
                return new Response("An unexpected error occurred: " + ex.Message, 500);
            }
        }

        [HttpGet("Get-All-WorkInfos")]
        public async Task<Response> GetAllWorkInfos([FromQuery] WorkInfoFilter filter, [FromQuery] WorkInfoSort sort)
        {
            try
            {
                if (filter == null || sort == null)
                    return new Response("Filter or sort parameters are null");

                var pagedWorkInfos = await workService.GetAllWorkInfoAsync(filter, sort);

                var WorkInfos = mapper.Map<PagedModel<WorkInfoDto>>(pagedWorkInfos);

                return new Response(WorkInfos, null, true, 200);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message);
            }
            catch (Exception ex)
            {
                return new Response("An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpPost("Add-WorkInfo")]
        public async Task<Response> AddWorkInfo([FromBody] CreateWorkInfoDto createWorkInfoDto)
        {
            if (createWorkInfoDto == null)
                return new Response("Please Provide Data", 400);


                var workInfo = mapper.Map<WorkInfo>(createWorkInfoDto);
                await workService.AddWorkInfoAsync(workInfo);

                return new Response("WorkInfo created successfully.", 200);               ;

        }

        [HttpPut("Update-WorkInfo")]
        public async Task<Response> UpdateWorkInfo([FromBody] UpdateWorkInfoDto updateWorkInfoDto)
        {

            if (updateWorkInfoDto == null)
                return new Response("WorkInfo is null.", 400);

            try
            {
                var existingCity = await workService.GetWorkInfoAsync(updateWorkInfoDto.Id);
                if (existingCity == null)
                    return new Response("WorkInfo not found.", 404);

                mapper.Map(updateWorkInfoDto, existingCity);
                await workService.UpdateWorkInfoAsync(existingCity);
                return new Response(null, "WorkInfo updated successfully.", true, 200);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, 400);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, 404);
            }
            catch (Exception ex)
            {
                return new Response("An unexpected error occurred: " + ex.Message, 500);
            }
        }

        [HttpDelete("Delete-WorkInfo")]
        public async Task<Response> DeleteWorkInfo(int id)
        {
            try
            {
                if (id <= 0)
                    return new Response("Invalid WorkInfo ID provided", 400);

                await workService.DeleteWorkInfoAsync(id);
                return new Response("WorkInfo deleted successfully", 200);
            }
            catch (ArgumentException ex)
            {
                return new Response(ex.Message, 400);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return new Response("An unexpected error occurred: " + ex.Message, 500);
            }
        }

    }
}
