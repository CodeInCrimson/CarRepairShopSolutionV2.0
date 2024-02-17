namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using Microsoft.EntityFrameworkCore;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(ClientModel client)
    {
        var dbClient = new DbClient
        {
            FirstName = client.Firstname,
            LastName = client.Lastname,
            PhoneNumber = client.Phonenumber
        };
        await _context.Clients.AddAsync(dbClient);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(ClientModel client)
    {
        var dbClient = await _context.Clients.FindAsync(client.Id);
        if (dbClient == null) return false;

        dbClient.FirstName = client.Firstname;
        dbClient.LastName = client.Lastname;
        dbClient.PhoneNumber = client.Phonenumber;
        _context.Clients.Update(dbClient);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int clientId)
    {
        var dbClient = await _context.Clients.FindAsync(clientId);
        if (dbClient == null) return false;

        _context.Clients.Remove(dbClient);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<ClientModel?> GetByIdAsync(int clientId)
    {
        var dbClient = await _context.Clients.FindAsync(clientId);
        return dbClient == null ? null : new ClientModel(dbClient.Id, dbClient.FirstName, dbClient.LastName, dbClient.PhoneNumber, dbClient.CreatedAt, dbClient.UpdatedAt);
    }

    public async Task<List<ClientModel>> GetAllAsync()
    {
        return await _context.Clients
            .Select(c => new ClientModel(c.Id, c.FirstName, c.LastName, c.PhoneNumber, c.CreatedAt, c.UpdatedAt))
            .ToListAsync();
    }
}
