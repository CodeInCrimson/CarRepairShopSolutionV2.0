// <copyright file="ISqliteDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShopSolution.Infrastructure.Persistence.DataAccess;

public interface ISqliteDbContext
{
    DbSet<T> Set<T>() where T : class;

    /// <summary>
    /// Exposes raw connection.
    /// </summary>
    DatabaseFacade Database { get; }

    Microsoft.Data.Sqlite.SqliteConnection GetConnection();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
