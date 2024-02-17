// <copyright file="ClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.ApplicationServices.RepositoryMappings;

using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Mappings;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class ClientService
{
    private readonly IRepository<DbClient> _clientRepository;

    public ClientService(IRepository<DbClient> clientRepository)
    {
        this._clientRepository = clientRepository;
    }

    public async Task AddClientAsync(ClientModel clientModel)
    {
        var dbClient = new DbClient
        {
            FirstName = clientModel.Firstname,
            LastName = clientModel.Lastname,
            PhoneNumber = clientModel.Phonenumber,
            CreatedAt = clientModel.CreatedAt,
            UpdatedAt = clientModel.UpdatedAt
        };

        // var dbClient = ModelMapping.MapToDbClient(clientModel);
        await _clientRepository.AddAsync(dbClient);
        // await _context.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(ClientModel clientModel)
    {
        var dbClient = ModelMapping.MapToDbClient(clientModel);
        await _clientRepository.AddAsync(dbClient);
        // await _clientRepository.UpdateAsync(dbClient);
    }

    public async Task DeleteClientAsync(int clientId)
    {
        var dbClient = await _clientRepository.GetByIdAsync(clientId);
        if (dbClient != null)
        {
            await _clientRepository.DeleteAsync(dbClient);
        }
    }

    public async Task<ClientModel> GetClientByIdAsync(int clientId)
    {
        var dbClient = await _clientRepository.GetByIdAsync(clientId);
        return ModelMapping.MapToClientModel(dbClient);
    }

    public async Task<List<ClientModel>> GetAllClientsAsync()
    {
        var dbClients = await _clientRepository.GetAllAsync();
        return dbClients.Select(ModelMapping.MapToClientModel).ToList();
    }
}
