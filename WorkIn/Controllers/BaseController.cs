using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Service.Contract;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected readonly IMapper mapper;
        private IProfileService profileService;

        public BaseController(IMapper mapper, IProfileService profileService)
        {
            this.mapper = mapper;
            this.profileService = profileService;
        }

    }
}
