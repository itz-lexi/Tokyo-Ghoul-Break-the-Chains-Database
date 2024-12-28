using BreakTheChains.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using BreakTheChains.Framework.Interfaces;
using BreakTheChains.Framework.Services;

var builder = WebApplication.CreateBuilder(args);

// Set up Serilog for logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.Debug(outputTemplate: "[Serilog] {Timestamp: HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configure DbContext with MySQL (using Pomelo Entity Framework)
builder.Services.AddDbContext<BreakTheChainsDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("BTCDB"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BTCDB"))));

builder.Services.AddScoped<ICharacterService, CharacterService>();

// Add controllers, Swagger, etc.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Starting application...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed.");
}
finally
{
    Log.Information("Shutting down...");
    Log.CloseAndFlush(); // Ensures all logs are flushed before the application exits
}
