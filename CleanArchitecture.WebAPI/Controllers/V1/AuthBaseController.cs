using Asp.Versioning;
using CleanArchitecture.Shared.SharedResoures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V1
{
    [ApiVersion(SharedResoure.V1_0)]
    [Route(SharedResoure.BaseRoutes)]
    [ApiController]
    [Authorize]
    public class AuthBaseController : Controller
    {
        public AuthBaseController() { }
    }
}