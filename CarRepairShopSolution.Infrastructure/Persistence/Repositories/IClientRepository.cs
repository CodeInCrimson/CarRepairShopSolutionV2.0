namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using CarRepairShopSolution.Domain.Models;

public interface IClientRepository
{
    Task<bool> AddAsync(ClientModel client);

    Task<bool> UpdateAsync(ClientModel client);

    Task<bool> DeleteAsync(int clientId);

    Task<ClientModel?> GetByIdAsync(int clientId);

    Task<List<ClientModel>> GetAllAsync();
}