using System.ComponentModel.DataAnnotations;

namespace F358.UserService.Database.Model;

internal class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreateDate { get; init; } = DateTime.UtcNow;
    
    
    [MaxLength(255)]
    public required string Login { get; set; }
    public required byte[] PasswordEncrypted { get; set; }
    public required int EncryptionVersion { get; set; }
    
    [MaxLength(255)]
    public required string FirstName { get; set; }
    
    [MaxLength(255)]
    public string? LastName { get; set; }
}