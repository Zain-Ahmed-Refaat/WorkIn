using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace WorkIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected readonly IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }

    }
}
