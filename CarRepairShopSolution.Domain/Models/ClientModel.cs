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
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="createdAt"></param>
    /// <param name="updatedAt"></param>
    public ClientModel(int id, string firstName, string lastName, string phoneNumber, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        : base(id, createdAt, updatedAt)
    {
        Firstname = firstName;
        Lastname = lastName;
        Phonenumber = phoneNumber;
    }

    public string Firstname { get; init; }

    public string Lastname { get; init; }

    public string Phonenumber { get; init; }
}
