using F358.Services.User.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace F358.Services.User.Database;

internal class UserDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Model.User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model.User>()
            .HasIndex(e => e.Login)
            .IncludeProperties(e => new { e.Id, e.PasswordEncrypted, e.EncryptionVersion });
    }
}