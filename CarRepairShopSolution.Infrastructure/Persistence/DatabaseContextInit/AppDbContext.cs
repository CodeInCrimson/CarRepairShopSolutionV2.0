namespace CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;

using CarRepairShopSolution.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<CarModel> Cars { get; set; }
    public DbSet<ClientModel> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=carRepairShop.db");
    }
}