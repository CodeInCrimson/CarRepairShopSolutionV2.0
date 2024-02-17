namespace CarRepairShopSolution.Infrastructure.Persistence.Factories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CarRepairShopSolution.Infrastructure.Persistence.DatabaseContextInit;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=carRepairShop.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
