using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Clean.Arch.Data.DatabaseContext;
using Clean.Arch.Domain.Interfaces;
using Clean.Arch.Domain.Entities;

namespace Clean.Arch.Data.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    public readonly DbSet<T> _dbSet;
    public readonly DataContext _dbContext;

    public Repository(DataContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
        _dbContext = dbContext;
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> DeleteAll(List<T> entities)
    {
        try
        {
            _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
            query = query.Where(filter)
                         .AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<T> GetById(Guid id)
        => await _dbSet.FindAsync(id);

    public async Task<bool> Insert(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> UpdateAll(List<T> entities)
    {
        try
        {
            _dbSet.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }
}
