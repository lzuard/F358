namespace F358.Services.User.Dto;

internal record NewUserDto
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}