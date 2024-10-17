using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.EmailConfigRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.ErrorLogRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.UserRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;
public interface IUnitOfWork
{
    Task<int> CompleteAsync();
    IErrorLogRepository ErrorLogRepository { get; }
    IUserRepository UserRepository { get; }
    IEmailConfigRepository EmailConfigRepository { get; }
}