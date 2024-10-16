using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StrideMemoDbContext _strideMemoDbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(StrideMemoDbContext strideMemoDbContext)
    {
        _strideMemoDbContext = strideMemoDbContext;
        _dbSet = strideMemoDbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        _strideMemoDbContext.Entry(entity).State = EntityState.Added;
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entity)
    {
        _strideMemoDbContext.Entry(entity).State = EntityState.Added;
        await _dbSet.AddRangeAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        T entity = await _dbSet.FirstAsync(x => x.Id == id);
        await DeleteAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        if (_strideMemoDbContext.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }

    public async Task DeleteRangeAsync(int[] ids)
    {
        var entity = await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        await DeleteRangeAsync(entity);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        var detachedEntities = entities.Where(entity => _strideMemoDbContext.Entry(entity).State == EntityState.Detached).ToList();
        if (detachedEntities.Any())
        {
            _dbSet.AttachRange(entities);
        }
        _dbSet.RemoveRange(entities);
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }
        return await Task.Run(() =>
        {
            return query.FirstOrDefault();
        });
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string SortField = "", int sortOrder = 1, string includeProperties = "")
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        var prop = await query.ToListAsync();

        if (!string.IsNullOrWhiteSpace(SortField))
        {
            return OrderBy<T>(query, SortField, sortOrder == 1 ? false : true);
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public static IQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> source, string orderByProperty, bool desc)
    {
        string command = desc ? "OrderByDescending" : "OrderBy";
        var type = typeof(TEntity);
        var property = type.GetProperty(orderByProperty);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                      source.Expression, Expression.Quote(orderByExpression));
        return source.Provider.CreateQuery<TEntity>(resultExpression);
    }

    public async Task<T> GetByIdAsync(int id, string includeProperties = "")
    {
        IQueryable<T> query = _dbSet;
        foreach (var includeProperty in includeProperties.Split
           (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return query.FirstOrDefault(x => x.Id == id);
    }

    public async Task<T> GetByIdWithoutTrackingAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _strideMemoDbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.AttachRange(entities);
        entities.ToList().ForEach(entity => _strideMemoDbContext.Entry(entity).State = EntityState.Modified);
    }
}
