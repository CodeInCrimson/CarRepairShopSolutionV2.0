// <copyright file="ICarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using CarRepairShopSolution.Domain.Models;

public interface ICarRepository
{
    Task<bool> AddAsync(CarModel car);

    Task<bool> UpdateAsync(CarModel car);

    Task<bool> DeleteAsync(int carId);

    Task<CarModel?> GetByIdAsync(int carId);

    Task<List<CarModel>> GetAllAsync();

    Task<List<CarModel>> GetAllAsyncOld();
}
