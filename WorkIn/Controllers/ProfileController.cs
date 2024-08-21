using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Service.Contract;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        public ProfileController(IMapper mapper, IProfileService profileService) : base(mapper, profileService)
        {
        }
    }
}
