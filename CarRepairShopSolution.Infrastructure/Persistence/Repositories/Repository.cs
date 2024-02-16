namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    public async Task DeleteAsync(T entity) => _context.Set<T>().Remove(entity);

    public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);
}
