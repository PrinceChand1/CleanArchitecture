using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;
public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.UserRepositoryRegistration();
        return services;
    }
}
