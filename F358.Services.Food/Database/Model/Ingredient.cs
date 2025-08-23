using System.ComponentModel.DataAnnotations;

namespace F358.Services.Food.Database.Model;

public class Ingredient : BaseEntity
{
    [MaxLength(255)]
    public required string Name { get; set; }
    
    public double? Сalories { get; set; }
    public double? Proteins { get; set; }
    public double? Carbs { get; set; }
    public double? Fats { get; set; }
    
    
    public virtual ICollection<RecipesIngredients> RecipeIngredients { get; set; } = null!;
}