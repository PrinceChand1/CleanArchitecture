using CleanArchitecture.Domain.Entities.LogEntities;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.LogRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.LogRepositories;
public class LogRepository : GenericRepository<Log>, ILogRepository
{
    public LogRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext) { }
}
