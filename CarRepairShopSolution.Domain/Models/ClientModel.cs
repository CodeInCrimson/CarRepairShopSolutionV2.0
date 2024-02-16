// <copyright file="ClientModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Domain.Models;
public record ClientModel : ModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientModel"/> class.
    /// Initial Client construction.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="createdAt"></param>
    /// <param name="updatedAt"></param>
    public ClientModel(int id, string name, string phoneNumber, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        : base(id, createdAt, updatedAt)
    {
        Name = name;
        Phonenumber = phoneNumber;
    }

    public string Name { get; init; }
    public string Phonenumber { get; init; }
}
