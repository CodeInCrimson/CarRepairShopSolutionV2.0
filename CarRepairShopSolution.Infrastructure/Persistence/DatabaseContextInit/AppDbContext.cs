// <copyright file="AppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;

using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<DbCar> Cars { get; set; }

    public DbSet<DbClient> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=carRepairShop.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbCar>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.DbClient)
                  .WithMany(client => client.Cars)
                  .HasForeignKey(c => c.ClientId);
        });

        modelBuilder.Entity<DbClient>(entity =>
        {
            entity.HasKey(c => c.Id);
        });
    }
}
