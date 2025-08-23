using System.ComponentModel.DataAnnotations;

namespace F358.Services.Food.Database.Model;

public class Recipe : BaseEntity
{
    public required Guid UserId { get; set; }
    public Guid? MainImageId { get; set; }
    
    [MaxLength(255)]
    public required string Name { get; set; }
    public double DefaultPortionSize { get; set; }
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    public int CookingTimeMinutes { get; set; }
    public int Complexity { get; set; }
    
    
    public virtual ICollection<RecipesIngredients> RecipeIngredients { get; set; } = null!;
    
    public virtual ICollection<RecipeImage>? OtherImages { get; set; } = null!;
}