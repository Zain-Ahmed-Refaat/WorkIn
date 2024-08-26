using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Domain.Common;
using ProfileEntity = WorkIn.Domain.Entities.Profile;
using WorkIn.Domain.Filters.Profile;
using WorkIn.Domain.Sorts.ProfileSort;
using WorkIn.Service.Contract;
using static WorkIn.Infrastructure.Dtos.Profile.ProfileDtos;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;

        public ProfileController(IMapper mapper, IProfileService profileService) : base(mapper)
        {
            this.profileService = profileService;
        }

        [HttpGet("Get-Profile")]
        public async Task<Response> GetByIdAsync(int id)
        {
            try
            {
                var profile = await profileService.GetProfileAsync(id);
                var profileDto = mapper.Map<ProfileDto>(profile);

                return new Response(profileDto, "Success", true, 200);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "Profile not found", false, 404);
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

        [HttpGet("Get-All-Profiles-No-Filter")]
        public async Task<IActionResult> GetAllProfilesNoFilter()
        {
            try
            {
                var profilesPagedModel = await profileService.GetAllProfilesNoFilter();
                var profileDtos = mapper.Map<PagedModel<ProfileDto>>(profilesPagedModel);

                return Ok(new Response(profileDtos, "Success", true, 200));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                });
            }
        }


        [HttpGet("Get-All-Profiles")]
        public async Task<Response> GetAllProfiles([FromQuery] ProfileFilter filter, [FromQuery] ProfileSort sort)
        {
            try
            {
                var profilePagedModel = await profileService.GetAllProfiles(filter, sort);

                var profileDtos = mapper.Map<PagedModel<ProfileDto>>(profilePagedModel);

                return new Response(profileDtos, "Success", true, 200);
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

        [HttpPost("Add-Profile")]
        public async Task<Response> AddProfileAsync([FromBody] CreateProfileDto createProfileDto)
        {
            if (createProfileDto == null)
                return new Response("Profile data is null.", 400);

            try
            {
                var Profile = mapper.Map<ProfileEntity>(createProfileDto);
                await profileService.AddProfileAsync(Profile);

                return new Response("Profile created successfully.", 200);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message, "An error occurred", false, 500)
                {
                    Errors = new { ExceptionMessage = ex.Message, ExceptionStackTrace = ex.StackTrace }
                };
            }
        }


        [HttpPut("Update-Profile")]
        public async Task<Response> UpdateProfileAsync([FromBody] UpdateProfileDto updateProfileDto)
        {
            if (updateProfileDto == null)
                return new Response("Profile data is null.", "Bad request", false, 400);


                var existingProfile = await profileService.GetProfileAsync(updateProfileDto.Id);
                if (existingProfile == null)
                    return new Response("Profile not found.", "Not found", false, 404);

                mapper.Map(updateProfileDto, existingProfile);
                await profileService.UpdateProfileAsync(existingProfile);

                return new Response("Profile updated successfully.", 200);

        }

        [HttpDelete("Delete-Profile")]
        public async Task<Response> DeleteAsync(int id)
        {
            try
            {
                await profileService.DeleteProfileAsync(id);
                return new Response("Profile deleted successfully.", 200);
            }
            catch (KeyNotFoundException ex)
            {
                return new Response(ex.Message, "Profile not found", false, 404);
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
