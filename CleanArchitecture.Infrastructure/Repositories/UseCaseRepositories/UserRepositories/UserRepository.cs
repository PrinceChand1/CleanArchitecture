using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.UserRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.UserRepositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext)
    {
    }
}
