using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UnityAnalytics.Back.Core.Application.Interfaces;
using UnityAnalytics.Back.Persistence.Context;

namespace UnityAnalytics.Back.Persistence.Repositories;

public class Repository <T> :  IRepository<T> where T : class, new()
{
    private readonly UABackContext _context;

    public Repository(UABackContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> GetByFilter(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
    }

    public async Task CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}