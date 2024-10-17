using CleanArchitecture.Domain.Entities.ErrorLogEntities;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.ErrorLogRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories.ErrorLogRepositories;
public class ErrorLogRepository : GenericRepository<ErrorLog>, IErrorLogRepository
{
    public ErrorLogRepository(StrideMemoDbContext strideMemoDbContext) : base(strideMemoDbContext) { }
}
