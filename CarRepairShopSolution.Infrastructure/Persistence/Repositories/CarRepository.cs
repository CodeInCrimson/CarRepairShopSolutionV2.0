// <copyright file="CarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using CarRepairShopSolution.Infrastructure.Persistence.Mappings;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(CarModel car)
    {
        var dbCar = ModelMapping.MapToDbCar(car);

        await _context.Cars.AddAsync(dbCar);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> UpdateAsync(CarModel car)
    {
        var dbCar = await _context.Cars.FindAsync(car.Id);
        if (dbCar == null)
        {
            return false;
        }

        dbCar.Brand = car.Brand;
        dbCar.Model = car.Model;
        dbCar.Year = car.Year;
        dbCar.ClientId = car.ClientId;

        _context.Cars.Update(dbCar);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int carId)
    {
        var dbCar = await _context.Cars.FindAsync(carId);
        if (dbCar == null) return false;

        _context.Cars.Remove(dbCar);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<CarModel?> GetByIdAsync(int carId)
    {
        var dbCar = await _context.Cars.FindAsync(carId);
        return dbCar != null ? new CarModel(dbCar.Brand, dbCar.Model, dbCar.Year, dbCar.ClientId, DateTimeOffset.Now, DateTimeOffset.Now) : null;
    }

    public async Task<List<CarModel>> GetAllAsync()
    {
        var cars = new List<CarModel>();
        var connectionString = _context.Database.GetDbConnection().ConnectionString;

        using (var connection = new SqliteConnection(connectionString))
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Brand, Model, Year, ClientId, CreatedAt, UpdatedAt FROM Cars";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("Id"));
                        var brand = reader.GetString(reader.GetOrdinal("Brand"));
                        var model = reader.GetString(reader.GetOrdinal("Model"));
                        var year = reader.GetInt32(reader.GetOrdinal("Year"));
                        var clientId = reader.GetInt32(reader.GetOrdinal("ClientId"));
                        var createdAt = reader.GetDateTimeOffset(reader.GetOrdinal("CreatedAt"));
                        var updatedAt = reader.GetDateTimeOffset(reader.GetOrdinal("UpdatedAt"));

                        // Set id in new constructor otherwise the data will not be displayed.
                        var newCarModel = new CarModel(id, brand, model, year, clientId, createdAt, updatedAt);

                        cars.Add(newCarModel);
                    }
                }
            }
        }

        return cars;
    }

    public async Task<List<CarModel>> GetAllAsyncOld()
    {
        return await _context.Cars.Select(c => new CarModel(c.Brand, c.Model, c.Year, c.ClientId, DateTimeOffset.Now, DateTimeOffset.Now)).ToListAsync();
    }
}
