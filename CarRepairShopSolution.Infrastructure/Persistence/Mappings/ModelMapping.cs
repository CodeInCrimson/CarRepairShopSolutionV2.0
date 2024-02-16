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
            Id = clientModel.Id,
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
            id: dbClient.Id,
            firstName: dbClient.FirstName,
            lastName: dbClient.LastName,
            phoneNumber: dbClient.PhoneNumber,
            createdAt: dbClient.CreatedAt,
            updatedAt: dbClient.UpdatedAt);
    }

    public static DbCar MapToDbCar(CarModel carModel)
    {
        return new DbCar
        {
            Id = carModel.Id,
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
            id: dbCar.Id,
            brand: dbCar.Brand,
            model: dbCar.Model,
            year: dbCar.Year,
            clientId: dbCar.ClientId,
            createdAt: dbCar.CreatedAt,
            updatedAt: dbCar.UpdatedAt);
    }
}
