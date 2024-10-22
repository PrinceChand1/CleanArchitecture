using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Shared.SharedResoures;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation();
        services.AddAutoMapper(typeof(CoreProfiler).Assembly);
        services.Configure<AppSettingsDto>(configuration.GetSection(SharedResoure.AppSettings));

        // Call the extension methods to register services
        services.AddHttpContextAccessor();
        services.UserServiceRegistration();
        return services;
    }
}
