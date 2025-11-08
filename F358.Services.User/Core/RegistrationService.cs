using F358.Services.User.Core.Validators;
using F358.Services.User.Database;
using F358.Services.User.Dto;
using F358.Shared.Dto;
using F358.Shared.Extensions;
using F358.Services.User.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace F358.Services.User.Core;

internal class RegistrationService(
    UserDbContext context,
    CryptoService cryptoService)
{
    private static readonly NewUserDtoValidator DtoValidator = new();
    
    public async Task<ProcessResult> RegisterUserAsync(NewUserDto userInfo, CancellationToken ct)
    {
        var result = new ProcessResult();

        if (!TryValidateDto(userInfo, result))
            return result;

        if (!await TryValidateUserAsync(userInfo, result, ct))
            return result;
        
        try
        {
            var userModel = CreateUser(userInfo);
            await context.Users.AddAsync(userModel, ct);
            await context.SaveChangesAsync(ct);
        }
        catch
        {
            result.Errors.Add("Could not register user");
            //TODO: add logging
        }
        
        return result;
    }

    
    private static bool TryValidateDto(NewUserDto userInfo, ProcessResult result)
    {
        var validationResult = DtoValidator.Validate(userInfo);

        if (validationResult is null)
            result.Errors.Add("Could not process your data.");
        else
        {
            result.Errors.UnionWith(validationResult.GetErrorMessages());
        }

        return validationResult?.IsValid is true;
    }

    
    private async Task<bool> TryValidateUserAsync(
        NewUserDto userInfo,
        ProcessResult result,
        CancellationToken ct)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(user =>
            user.Login.ToLower() == userInfo.Login!.ToLower(), ct);

        if (existingUser is not null)
            result.Errors.Add("Login is already in use.");
        
        return result.Errors.Count == 0;
    }

    
    private Database.Model.User CreateUser(NewUserDto userInfo)
    {
        var data = cryptoService.Encrypt(userInfo.Password!);

        return new Database.Model.User
        {
            Login = userInfo.Login!,
            PasswordEncrypted = data.Data,
            EncryptionVersion = data.Version,
            FirstName = userInfo.FirstName!,
            LastName = userInfo.LastName
        };
    }
}