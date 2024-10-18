using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.EmailConfigRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.ErrorLogRepositories;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories.UserRepositories;

namespace CleanArchitecture.Infrastructure.Repositories.UseCaseRepositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly StrideMemoDbContext _strideMemoDbContext;

    public UnitOfWork(StrideMemoDbContext strideMemoDbContext,
        IErrorLogRepository errorLogRepository,
        IUserRepository userRepository,
        IEmailConfigRepository emailConfigRepository)
    {
        _strideMemoDbContext = strideMemoDbContext;
        ErrorLogRepository = errorLogRepository;
        UserRepository = userRepository;
        EmailConfigRepository = emailConfigRepository;
    }

    public IErrorLogRepository ErrorLogRepository { get; }
    public IUserRepository UserRepository { get; }
    public IEmailConfigRepository EmailConfigRepository { get; }

    public async Task<int> CompleteAsync()
    {
        try
        {
            string userName = string.Empty;
            //var user = securityBuilder.GetUser();
            //if (user != null)
            //{
            //    userName = user.Email;
            //}
            var allSavedEntries = _strideMemoDbContext.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added || x.State == Microsoft.EntityFrameworkCore.EntityState.Modified).ToList();
            foreach (var entry in allSavedEntries)
            {
                var entity = (BaseAuditableEntity)entry.Entity;

                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.CreatedBy = userName;
                    entity.IsDeleted = false;
                }
                else
                {
                    entry.Property("CreatedOn").IsModified = false;
                    entry.Property("CreatedBy").IsModified = false;
                    entity.ModifiedOn = DateTime.Now;
                    entity.ModifiedBy = userName;
                }
            }
            return await _strideMemoDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _strideMemoDbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void ClearEntities()
    {
        _strideMemoDbContext.ChangeTracker.Clear();
    }
}