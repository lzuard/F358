using DotNetEnv;
using F358.Services.Food.Database;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddNpgsql<FoodDbContext>(Environment.GetEnvironmentVariable("CONNECTION_STRING"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
