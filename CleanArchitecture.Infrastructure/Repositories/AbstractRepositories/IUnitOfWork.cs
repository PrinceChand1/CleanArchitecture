using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.EmailConfigRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.LogRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.UserRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;
public interface IUnitOfWork
{
    Task<int> CompleteAsync();
    ILogRepository ErrorLogRepository { get; }
    IUserRepository UserRepository { get; }
    IEmailConfigRepository EmailConfigRepository { get; }
}