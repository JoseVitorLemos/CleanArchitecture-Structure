using System.Linq.Expressions;
using Clean.Arch.Domain.Entities;

namespace Clean.Arch.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
    Task<T> GetById(Guid id);
    Task<bool> Insert(T entity);
    Task<bool> Update(T entity);
    Task<bool> UpdateAll(List<T> entities);
    Task<bool> Delete(Guid id);
    Task<bool> DeleteAll(List<T> entities);
}
