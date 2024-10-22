using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoutes)]
    [ApiController]
    [Authorize]
    public class AuthBaseController : Controller
    {
        public AuthBaseController() { }
    }
}
