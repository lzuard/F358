namespace F358.Shared.Model.Auth;

public record NewUserRequest(
    string? Login,
    string? Password,
    string? FirstName,
    string? LastName);