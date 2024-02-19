// <copyright file="CarModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Domain.Models;
public record CarModel : ModelBase
{
    // private readonly int _id;
    public CarModel(string brand, string model, int year, int clientId, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        : base(createdAt, updatedAt)
    {
        Brand = brand;
        Model = model;
        Year = year;
        ClientId = clientId;
    }

    public CarModel(int id, string brand, string model, int year, int clientId, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        : base(createdAt, updatedAt)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        ClientId = clientId;
    }

    public string Brand { get; init; }

    public string Model { get; init; }

    public int Year { get; init; }

    public int ClientId { get; init; }

    /// <summary>
    /// To be later used for test data generator.
    /// </summary>

#pragma warning disable SA1005 // Single line comments should begin with single space
                              //public static CarModel New(
                              //    string brand,
                              //    string model,
                              //    int year,
                              //    int clientId)
                              //{
                              //    return new CarModel(
                              //        Id,
                              //        ClientId,
                              //        null,
                              //        null)
                              //    {
                              //        Brand = brand,
                              //        Model = model,
                              //        Year = year,
                              //        ClientId = clientId,
                              //    };
#pragma warning restore SA1005 // Single line comments should begin with single space
}
