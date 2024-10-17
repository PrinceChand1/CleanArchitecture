using CleanArchitecture.Application.Mapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddAutoMapper(typeof(CoreProfiler).Assembly);

        // Call the extension methods to register services
        services.AddHttpContextAccessor();
        services.UserServiceRegistration();
        return services;
    }
}
