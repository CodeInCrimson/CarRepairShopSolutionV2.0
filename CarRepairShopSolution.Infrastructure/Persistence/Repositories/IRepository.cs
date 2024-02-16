namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
