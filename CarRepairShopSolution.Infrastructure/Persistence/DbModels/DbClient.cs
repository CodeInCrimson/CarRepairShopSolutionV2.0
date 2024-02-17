// <copyright file="DbClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.DbModels;

public class DbClient : DbEntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public virtual ICollection<DbCar> Cars { get; set; } = new List<DbCar>();
}
