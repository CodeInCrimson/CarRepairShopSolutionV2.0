// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using CarRepairShopSolution.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<T>
    where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task AddAsync(ClientModel clientModel);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
