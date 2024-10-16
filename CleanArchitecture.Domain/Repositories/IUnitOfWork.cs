using CleanArchitecture.Domain.Repositories.EmailConfigRepositories;
using CleanArchitecture.Domain.Repositories.ErrorLogRepositories;
using CleanArchitecture.Domain.Repositories.UserRepositories;

namespace CleanArchitecture.Domain.Repositories;
public interface IUnitOfWork
{
    IErrorLogRepository ErrorLogRepository { get; }
    IUserRepository UserRepository { get; }
    IEmailConfigRepository EmailConfigRepository { get; }
}