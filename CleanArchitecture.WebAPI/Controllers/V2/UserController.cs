using Asp.Versioning;
using CleanArchitecture.Shared.SharedResoures;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route(SharedResoure.BaseRoutes)]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
