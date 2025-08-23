using System.ComponentModel.DataAnnotations;

namespace F358.Services.Food.Database.Model;

public class RecipeStep : BaseEntity
{
    public Guid RecipeId { get; set; }
    
    public int StepNumber { get; set; }
    [MaxLength(1000)]
    public required string Description { get; set; }
    public Guid? ImageId { get; set; }
    
    public virtual Recipe Recipe { get; set; } = null!;
}