using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Domain.Repositories.UserRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.UserRepositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext)
    {
    }
}
