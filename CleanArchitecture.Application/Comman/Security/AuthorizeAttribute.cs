using CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Shared.SharedResoures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Contracts;
using System.Web.Http.Controllers;

namespace CleanArchitecture.Application.Comman.Security;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (UserResponseDto)context.HttpContext.Items["User"];
        if (user == null)
        {
            context.Result = new JsonResult(new Result<bool> { Success = false, Error = SharedResoure.UnAuthorizeUser, ErrorCode = 403 });
        }
    }

    private static bool SkipAuthorization(HttpActionContext actionContext)
    {
        Contract.Assert(actionContext != null);

        return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
    }
}
