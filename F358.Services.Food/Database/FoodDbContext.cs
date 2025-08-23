using F358.Services.Food.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace F358.Services.Food.Database;

public class FoodDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeImage> RecipeImages { get; set; } = null!;
    public DbSet<RecipesIngredients> RecipesIngredients { get; set; } = null!;
    public DbSet<RecipeStep>  RecipeSteps { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipesIngredients>().Configure();
    }
}