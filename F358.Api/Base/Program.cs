using System.Security.Cryptography;
using F358.Api.Base;
using F358.Api.Middleware;
using F358.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApiDocument();
builder.Services.AddControllers();

builder.Services.AddSingleton<AuthMiddleware>();
builder.Services.AddScoped<FinancesClient<UserServiceOptions>>();


builder.Services.Configure<UserServiceOptions>(builder.Configuration.GetSection("UserService"));
builder.Services.Configure<Secrets>(builder.Configuration.GetSection("Secrets"));
builder.Services.AddAuthentication()
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var rsa = RSA.Create();
        rsa.ImportRSAPublicKey(Convert.FromBase64String(builder.Configuration["Secrets:UserServiceTokenKey"]!), out _);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new RsaSecurityKey(rsa)
        };
        options.MapInboundClaims = true;
    });
builder.Services.AddEndpointsApiExplorer();
var allowedOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>() ??
                     throw new ArgumentNullException();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Started in development mode");
    app.MapOpenApi();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseCors(policy => policy
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins(allowedOrigins));

app.UseMiddleware<AuthMiddleware>();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();