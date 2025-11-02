using DotNetEnv;
using F358.UserService.Base;
using F358.UserService.Core;
using F358.UserService.Database;
using Microsoft.EntityFrameworkCore;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.Configure<LoginOptions>(builder.Configuration.GetSection(LoginOptions.SectionName));

builder.Services.AddNpgsql<UserDbContext>(
    connectionString: Environment.GetEnvironmentVariable("CONNECTION_STRING"),
    npgSqlOptions =>
    {
        npgSqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CryptoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.AddRoutes();

app.UseHttpsRedirection();

app.Run();