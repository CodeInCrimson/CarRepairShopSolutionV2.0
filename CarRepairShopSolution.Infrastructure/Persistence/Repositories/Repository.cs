namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.Mappings;

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

    public async Task AddAsync(ClientModel clientModel)
    {
        var dbClient = ModelMapping.MapToDbClient(clientModel);
        await _context.Clients.AddAsync(dbClient);
        await _context.SaveChangesAsync();
    }
}
