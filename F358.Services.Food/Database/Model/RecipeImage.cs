namespace F358.Services.Food.Database.Model;

public class RecipeImage : BaseEntity
{
    public Guid RecipeId { get; set; }
    
    public virtual Recipe Recipe { get; set; } = null!;
}