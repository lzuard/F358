namespace F358.UserService.Dto;

internal record NewUserDto
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}