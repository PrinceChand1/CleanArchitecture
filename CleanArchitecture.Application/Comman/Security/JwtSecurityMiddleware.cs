using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CleanArchitecture.Application.Comman.Security;
public class JwtSecurityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettingsDto _appSettingDto;

    public JwtSecurityMiddleware(RequestDelegate next, IOptions<AppSettingsDto> appSettingDto)
    {
        _next = next;
        _appSettingDto = appSettingDto.Value;
    }

    public async Task InvokeAsync(HttpContext httpContext, IUserService userService)
    {
        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await attachUserToContext(httpContext, userService, token);

        await _next(httpContext);
    }

    private async Task attachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettingDto.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidAudience = _appSettingDto.Audience,
                ValidIssuer = _appSettingDto.Issuer,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

            //Attach user to context on successful JWT validation
            //var result = await userService.GetById(int.Parse(userId), string.Empty);
            //context.Items["User"] = result.Data;
        }
        catch
        {
            // Do nothing if JWT validation fails
        }
    }
}
