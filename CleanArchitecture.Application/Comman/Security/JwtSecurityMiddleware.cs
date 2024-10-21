using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CleanArchitecture.Application.Comman.Security;
public class JwtSecurityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppsettingDto _appsettingDto;

    public JwtSecurityMiddleware(RequestDelegate next, IOptions<AppsettingDto> appsettingDto)
    {
        _next = next;
        _appsettingDto = appsettingDto.Value;
    }

    public async Task InvokeAsync(HttpContext httpContext, UserManager<IUserService> userService)
    {
        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await attachUserToContext(httpContext, userService, token);

        await _next(httpContext);
    }

    private async Task attachUserToContext(HttpContext context, UserManager<IUserService> userManager, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettingDto.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidAudience = _appsettingDto.Audience,
                ValidIssuer = _appsettingDto.Issuer,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

            // Attach the user to the context using Identity
            var user = await userManager.FindByIdAsync(userId);
            context.Items["User"] = user;
        }
        catch
        {
            // Do nothing if JWT validation fails
        }
    }
}
