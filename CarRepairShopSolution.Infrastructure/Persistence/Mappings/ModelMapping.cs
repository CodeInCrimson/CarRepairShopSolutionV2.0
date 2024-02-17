// <copyright file="ModelMapping.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.Mappings;

using CarRepairShopSolution.Domain.Models;
using CarRepairShopSolution.Infrastructure.Persistence.DbModels;

public static class ModelMapping
{
    public static DbClient MapToDbClient(ClientModel clientModel)
    {
        return new DbClient
        {
            FirstName = clientModel.Firstname,
            LastName = clientModel.Lastname,
            PhoneNumber = clientModel.Phonenumber,
            CreatedAt = clientModel.CreatedAt,
            UpdatedAt = clientModel.UpdatedAt,
        };
    }

    public static ClientModel MapToClientModel(DbClient dbClient)
    {
        return new ClientModel(
            dbClient.FirstName,
            dbClient.LastName,
            dbClient.PhoneNumber,
            dbClient.CreatedAt,
            dbClient.UpdatedAt);
    }

    public static DbCar MapToDbCar(CarModel carModel)
    {
        return new DbCar
        {
            Brand = carModel.Brand,
            Model = carModel.Model,
            Year = carModel.Year,
            ClientId = carModel.ClientId,
            CreatedAt = carModel.CreatedAt,
            UpdatedAt = carModel.UpdatedAt,
        };
    }

    public static CarModel MapToCarModel(DbCar dbCar)
    {
        return new CarModel(
            brand: dbCar.Brand,
            model: dbCar.Model,
            year: dbCar.Year,
            clientId: dbCar.ClientId,
            createdAt: dbCar.CreatedAt,
            updatedAt: dbCar.UpdatedAt);
    }
}
