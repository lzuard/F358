using F358.UserService.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace F358.UserService.Database;

internal class UserDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Login)
            .IncludeProperties(e => new { e.Id, e.PasswordEncrypted, e.EncryptionVersion });
    }
}