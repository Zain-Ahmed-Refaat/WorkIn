using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Service.Contract;
using WorkIn.Domain.Filters.Department;
using WorkIn.Domain.Sorts.Department;
using static WorkIn.Infrastructure.Dtos.Department.DepartmentDtos;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper) : base(mapper)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("Get-Department")]
        public async Task<Response> GetDepartmentAsync(int departmentId)
        {
            try
            {
                if (departmentId <= 0)
                    return new Response("Invalid department ID.", 400);

                var department = await departmentService.GetDepartmentAsync(departmentId);
                var departmentDto = mapper.Map<DepartmentDto>(department);
                return new Response(departmentDto, "Success", true, 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpGet("Get-All-Departments")]
        public async Task<Response> GetAllDepartments([FromQuery] DepartmentFilter filter, [FromQuery] DepartmentSort sort)
        {
            try
            {

                var departments = await departmentService.GetAllDepartments(filter, sort);

                var departmentDtos = mapper.Map<PagedModel<DepartmentDto>>(departments);

                return new Response(departmentDtos, "Success", true, 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }


        [HttpPost("Add-Department")]
        public async Task<Response> CreateDepartmentAsync([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            if (createDepartmentDto == null)
                return new Response("Department data is null.", 400);

            try
            {
                var department = mapper.Map<Department>(createDepartmentDto);
                await departmentService.AddDepartmentAsync(department);
                var departmentDto = mapper.Map<DepartmentDto>(department);
                return new Response("Department created successfully.")
                {
                    Data = new { id = department.Id }
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

        [HttpPut("Update-Department")]
        public async Task<Response> UpdateDepartmentAsync([FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            if (updateDepartmentDto == null)
                return new Response("Department data is null.", 400);

            try
            {
                var existingDepartment = await departmentService.GetDepartmentAsync(updateDepartmentDto.Id);
                if (existingDepartment == null)
                    return new Response("Department not found.", 404);

                mapper.Map(updateDepartmentDto, existingDepartment);
                await departmentService.UpdateDepartmentAsync(existingDepartment);
                return new Response(null, "Department updated successfully.", true, 204);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }

        [HttpDelete("Delete-Department")]
        public async Task<Response> DeleteDepartmentAsync(int departmentId)
        {
            try
            {
                if (departmentId <= 0)
                    return new Response("Invalid department ID.", 400);

                await departmentService.DeleteDepartmentAsync(departmentId);
                return new Response(null, "Department deleted successfully.", true, 204);
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
