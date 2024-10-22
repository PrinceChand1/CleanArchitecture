﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoutes)]
    [ApiController]
    public class UnAuthBaseController : Controller
    {
        public UnAuthBaseController() { }
    }
}
