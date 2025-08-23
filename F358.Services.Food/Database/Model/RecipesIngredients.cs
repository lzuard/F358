using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F358.Services.Food.Database.Model;

public class RecipesIngredients
{
    public Guid RecipeId { get; set; }
    public Guid IngredientId { get; set; }
    
    public double Grams { get; set; }
    
    
    public virtual Ingredient Ingredient { get; set; } = null!;
    public virtual Recipe Recipe { get; set; } = null!;
}

public static class RecipesIngredientsConfiguration
{
    public static void Configure(this EntityTypeBuilder<RecipesIngredients> builder)
    {
        builder.HasKey(r => new { r.RecipeId, r.IngredientId });
        
        builder
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId);
        
        builder
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId);
    }
}