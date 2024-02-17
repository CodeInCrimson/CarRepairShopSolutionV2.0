// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;
using CarRepairShopSolution.Domain.Models;

public class Repository<T> : IRepository<T>
    where T : class
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

    /// <summary>
    /// Requirement from given task: Database operation with ADO.NET
    /// TODO: Move method to another location or update in order to retrieve all cars to be displayed.
    /// </summary>
    /// <param name="carId"></param>
    /// <returns></returns>
    public async Task<CarModel?> GetCarByIdWithAdoNetAsync(int carId)
    {
        string connectionString = this._context.Database.GetDbConnection().ConnectionString;
        using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);

        await connection.OpenAsync();

        var command = connection.CreateCommand();

        command.CommandText = @"SELECT Id, Brand, Model, Year, ClientId FROM Cars WHERE Id = $id";
        command.Parameters.AddWithValue("$id", carId);

        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new CarModel(
                brand: reader.GetString(1),
                model: reader.GetString(2),
                year: reader.GetInt32(3),
                clientId: reader.GetInt32(4),
                createdAt: DateTimeOffset.Now,
                updatedAt: DateTimeOffset.Now);
        }

        return null;
    }
}
