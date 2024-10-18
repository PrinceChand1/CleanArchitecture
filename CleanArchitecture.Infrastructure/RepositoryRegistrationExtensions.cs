using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.EmailConfigRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.ErrorLogRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.UserRepositories;
using CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories;
using CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.EmailConfigRepositories;
using CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.ErrorLogRepositories;
using CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.UserRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;
public static class RepositoryRegistrationExtensions
{
    public static IServiceCollection UserRepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailConfigRepository, EmailConfigRepository>();
        services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
