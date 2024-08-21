using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkIn.Service.Contract;

namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : BaseController
    {
        public JobTitleController(IMapper mapper, IProfileService profileService) : base(mapper, profileService)
        {
        }
    }
}
