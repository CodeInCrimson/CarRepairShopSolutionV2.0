// <copyright file="DbCar.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.DbModels;

public class DbCar : DbEntityBase
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    /// <summary>
    /// Foreign Key.
    /// </summary>
    public int ClientId { get; set; }

    public virtual DbClient DbClient { get; set; }
}
