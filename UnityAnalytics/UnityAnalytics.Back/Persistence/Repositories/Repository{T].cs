using System.Linq.Expressions;
using UnityAnalytics.Back.Core.Application.Interfaces;

namespace UnityAnalytics.Back.Persistence.Repositories;

public class Repository <T> :  IRepository<T> where T : class, new()
{
    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(object id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByFilter(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(T entity)
    {
        throw new NotImplementedException();
    }
}