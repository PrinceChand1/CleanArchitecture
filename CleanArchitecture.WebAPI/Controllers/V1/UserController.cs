using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V1
{
    public class UserController : AuthBaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Ok("OK");
        }
    }
}
