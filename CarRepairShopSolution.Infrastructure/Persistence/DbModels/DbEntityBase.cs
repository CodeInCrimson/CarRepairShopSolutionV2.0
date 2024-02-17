namespace CarRepairShopSolution.Infrastructure.Persistence.DbModels;

public abstract class DbEntityBase
{
    public int Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}
