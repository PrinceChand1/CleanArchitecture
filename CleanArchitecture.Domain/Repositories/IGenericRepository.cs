using CleanArchitecture.Domain.Entities;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Repositories;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entity);
    Task DeleteAsync(int id);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(int[] ids);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task<T?> FindAsync(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string SortField = "", int sortOrder = 1,
            string includeProperties = "");
    Task<T> GetByIdAsync(int id, string includeProperties = "");
    Task<T> GetByIdWithoutTrackingAsync(int id);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
}
