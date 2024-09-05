using System.Linq.Expressions;

namespace UnityAnalytics.Back.Core.Application.Interfaces;

public interface IRepository<T> where T : class, new()
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object id);
    Task<T?> GetByFilter(Expression<Func<T, bool>> filter);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}