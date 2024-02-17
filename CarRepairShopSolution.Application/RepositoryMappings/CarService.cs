// <copyright file="CarService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.ApplicationServices.RepositoryMappings;

using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Mappings;
using CarRepairShopSolution.Infrastructure.Persistence.Repositories;
public class CarService
{
    private readonly IRepository<DbCar> _carRepository;

    public CarService(IRepository<DbCar> carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task AddCarAsync(CarModel carModel)
    {
        var dbCar = ModelMapping.MapToDbCar(carModel);
        await _carRepository.AddAsync(dbCar);
    }

    public async Task UpdateCarAsync(CarModel carModel)
    {
        var dbCar = ModelMapping.MapToDbCar(carModel);
        await _carRepository.UpdateAsync(dbCar);
    }

    public async Task DeleteCarAsync(int carId)
    {
        var dbCar = await _carRepository.GetByIdAsync(carId);
        if (dbCar != null)
        {
            await _carRepository.DeleteAsync(dbCar);
        }
    }

    public async Task<CarModel> GetCarByIdAsync(int carId)
    {
        var dbCar = await _carRepository.GetByIdAsync(carId);
        return ModelMapping.MapToCarModel(dbCar);
    }

    public async Task<List<CarModel>> GetAllCarsAsync()
    {
        var dbCars = await _carRepository.GetAllAsync();
        return dbCars.Select(ModelMapping.MapToCarModel).ToList();
    }
}
