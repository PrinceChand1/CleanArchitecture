using CleanArchitecture.Application.Services.AbstractServices;
using CleanArchitecture.Application.Services.AbstractServices.EmailConfigs;
using CleanArchitecture.Application.Services.AbstractServices.ErrorLogs;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using CleanArchitecture.Application.Services.UserCases;
using CleanArchitecture.Application.Services.UserCases.EmailConfigs;
using CleanArchitecture.Application.Services.UserCases.Users;
using CleanArchitecture.Application.Services.UserCaseServices.ErrorLogs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;
public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddHttpContextAccessor(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        return services;
    }

    public static IServiceCollection UserServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailConfigService, EmailConfigService>();
        services.AddScoped<IErrorLogService, ErrorLogService>();
        services.AddScoped<IExport, Export>();
        return services;
    }
}
