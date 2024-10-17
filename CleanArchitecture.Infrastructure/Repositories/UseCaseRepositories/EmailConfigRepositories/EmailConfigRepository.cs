using CleanArchitecture.Domain.Entities.EmailConfigEntities;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.EmailConfigRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.EmailConfigRepositories;
public class EmailConfigRepository : GenericRepository<EmailConfig>, IEmailConfigRepository
{
    public EmailConfigRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext)
    {
    }
}
