namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Mappings;
using Microsoft.Data.Sqlite;
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
        var dbClient = ModelMapping.MapToDbClient(client);

        await _context.Clients.AddAsync(dbClient);
        var result = await _context.SaveChangesAsync();

        return result > 0;
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
        return dbClient == null ? null : new ClientModel(dbClient.FirstName, dbClient.LastName, dbClient.PhoneNumber, dbClient.CreatedAt, dbClient.UpdatedAt);
    }

    /// <summary>
    ///  Requirement from given task: Database operation with ADO.NET.
    /// </summary>
    /// <returns></returns>
    public async Task<List<ClientModel>> GetAllAsync()
    {
        var clients = new List<ClientModel>();
        var connectionString = _context.Database.GetDbConnection().ConnectionString;

        using (var connection = new SqliteConnection(connectionString))
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, FirstName, LastName, PhoneNumber, CreatedAt, UpdatedAt FROM Clients";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("Id"));
                        var firstname = reader.GetString(reader.GetOrdinal("FirstName"));
                        var lastname = reader.GetString(reader.GetOrdinal("LastName"));
                        var phonenumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                        var createdAt = reader.GetDateTimeOffset(reader.GetOrdinal("CreatedAt"));
                        var updatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("UpdatedAt"));

                        // Set id in new constructor otherwise the data will not be displayed.
                        var newClientModel = new ClientModel(id, firstname, lastname, phonenumber, createdAt, updatedAt);

                        clients.Add(newClientModel);
                    }
                }
            }
        }

        return clients;
    }

    public async Task<List<ClientModel>> GetAllAsyncOld()
    {
        return await _context.Clients
            .Select(c => new ClientModel(c.FirstName, c.LastName, c.PhoneNumber, c.CreatedAt, c.UpdatedAt))
            .ToListAsync();
    }

    /*
    public async Task<List<ClientModel>> GetAllAsyncOld()
    {
        return await _context.Clients
            .Select(c => new ClientModel(c.Id, c.FirstName, c.LastName, c.PhoneNumber, c.CreatedAt, c.UpdatedAt))
            .ToListAsync();
    }
    */
}
