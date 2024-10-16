using CleanArchitecture.Domain.Entities.EmailConfigEntities;
using CleanArchitecture.Domain.Repositories.EmailConfigRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.EmailConfigRepositories;
public class EmailConfigRepository : GenericRepository<EmailConfig>, IEmailConfigRepository
{
    public EmailConfigRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext)
    {
    }
}
