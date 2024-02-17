// <copyright file="ClientModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace CarRepairShopSolution.Domain.Models;
public record ClientModel : ModelBase
{
    public string Firstname { get; init; }

    public string Lastname { get; init; }

    public string Phonenumber { get; init; }

    public List<CarModel> Cars { get; set; } = new List<CarModel>();

    public string DisplayCars => Cars.Count > 0 ? string.Join(", ", Cars.Select(c => c.Model)) : "0";

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
    public ClientModel(string firstName, string lastName, string phoneNumber, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        : base(createdAt, updatedAt)
    {
        Firstname = firstName;
        Lastname = lastName;
        Phonenumber = phoneNumber;
    }

    public ClientModel(int id, string firstName, string lastName, string phoneNumber, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        : base(createdAt, updatedAt)
    {
        Id = id;
        Firstname = firstName;
        Lastname = lastName;
        Phonenumber = phoneNumber;
    }

    private ClientModel(
        int id,
        DateTimeOffset? createdAt,
        DateTimeOffset? updatedAt)
        : base(createdAt, updatedAt)
    {
    }

    /*
    public static ClientModel New(
        string firstName,
        string lastName,
        string phoneNumber)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        var model = new ClientModel(
            id,
            firstName,
            lastName,
            phoneNumber,
            null,
            null);
#pragma warning restore CS0618 // Type or member is obsolete

        return model;
    }
    */
}
