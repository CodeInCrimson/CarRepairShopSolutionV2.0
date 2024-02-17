// <copyright file="AppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;

using CarRepairShopSolution.Infrastructure.Persistence.DbModels;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<DbCar> Cars { get; set; }

    public DbSet<DbClient> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbCar>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasOne(c => c.DbClient).WithMany(client => client.Cars).HasForeignKey(c => c.ClientId);
        });

        modelBuilder.Entity<DbClient>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    }
}
