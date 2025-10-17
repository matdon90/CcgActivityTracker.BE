using CcgActivityTracker.Application.Activities.Handlers;
using CcgActivityTracker.Domain.Interfaces;
using CcgActivityTracker.Infrastructure.Persistence;
using CcgActivityTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<CreateActivityHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/healthz", () => Results.Ok("ok"));
app.MapGet("/version", () => typeof(Program).Assembly.GetName().Version?.ToString());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    Console.WriteLine("EF Core migrations have been applied.");
}

app.Run();

public partial class Program { }
