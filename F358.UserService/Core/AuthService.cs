using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using F358.Shared.Dto;
using F358.UserService.Base;
using F358.UserService.Database;
using F358.UserService.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace F358.UserService.Core;

internal class AuthService(
    UserDbContext context,
    CryptoService cryptoService,
    IOptions<SecretOptions> secretOptions,
    IOptions<LoginOptions> loginOptions)
{
    private readonly Random _random = new();
    public async Task<ProcessResultWithData<string?>> LoginAsync(LoginDto dto, CancellationToken ct)
    {
        await AddRandomDelay(ct);
        var result = new ProcessResultWithData<string?>();
        
        var userId = await GetUserIdOrDefault(dto.Login, dto.Password, ct);

        if (userId is null)
        {
            result.Errors.Add("Invalid login or password");
            return result;
        }

        var token = GenerateToken(userId.Value);
        
        result.Data =
        [
            new JwtSecurityTokenHandler().WriteToken(token)
        ];
        
        return result;
    }

    
    private Task AddRandomDelay(CancellationToken ct) => Task.Delay(
        _random.Next(
            loginOptions.Value.LoginDelayMinMs, 
            loginOptions.Value.LoginDelayMaxMs), 
        ct);
    
    
    private async Task<Guid?> GetUserIdOrDefault(string? login, string? password, CancellationToken ct)
    {
        if (login is null || password is null)
            return null;

        var user = await context.Users
            .Where(user => user.Login == login)
            .Select(user => new {user.Id, user.PasswordEncrypted, user.EncryptionVersion})
            .FirstOrDefaultAsync(ct);
        
        if(user is null)
            return null;

        var decryptedPassword = cryptoService.Decrypt(user.PasswordEncrypted, user.EncryptionVersion);

        return decryptedPassword != password ? null : user.Id;
    }

    
    private JwtSecurityToken GenerateToken(Guid userId)
    {
        ArgumentNullException.ThrowIfNull(secretOptions.Value.JwtKey);

        var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(
            Convert.FromBase64String(secretOptions.Value.JwtKey), out _);
        
        var signingCredentials = new SigningCredentials(
            key: new RsaSecurityKey(rsa),
            algorithm: SecurityAlgorithms.RsaSha256);
        
        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(loginOptions.Value.TokenLifeTime),
            claims: GetClaims(userId),
            signingCredentials: signingCredentials);
        
        return token;
    }
    
    private static List<Claim> GetClaims(Guid userId) => 
    [
        new("userId", userId.ToString())
    ];
}