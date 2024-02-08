using Clean.Arch.Data.DatabaseContext;
using Clean.Arch.Domain.Entities;
using Clean.Arch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clean.Arch.Data.Repositories;

public class IndividualEntityRepository : IIndividualEntityRepository
{
    private readonly DataContext _dbContext;

    public IndividualEntityRepository(DataContext context)
    {
        _dbContext = context;
    }

    public async Task<List<IndividualEntity>> GetAll()
        => await _dbContext.IndividualEntities.ToListAsync();

    public async Task<IndividualEntity> GetById(int id)
        => await _dbContext.IndividualEntities.FindAsync(id);

    public async Task<IndividualEntity> Insert(IndividualEntity entity)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IndividualEntity> Update(IndividualEntity entity)
    { 
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<IndividualEntity>> UpdateAll(List<IndividualEntity> entities)
    { 
        _dbContext.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
        return entities;
    }

    public async Task<IndividualEntity> Delete(IndividualEntity entity)
    { 
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<IndividualEntity>> DeleteAll(List<IndividualEntity> entities)
    { 
        _dbContext.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
        return entities;
    }
}
