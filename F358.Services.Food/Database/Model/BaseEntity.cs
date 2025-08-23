namespace F358.Services.Food.Database.Model;

public abstract class BaseEntity
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}