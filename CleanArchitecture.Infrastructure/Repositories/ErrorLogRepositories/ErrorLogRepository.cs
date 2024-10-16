using CleanArchitecture.Domain.Entities.ErrorLogEntities;
using CleanArchitecture.Domain.Repositories.ErrorLogRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.ErrorLogRepositories;
public class ErrorLogRepository : GenericRepository<ErrorLog>, IErrorLogRepository
{
    public ErrorLogRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext) { }
}
