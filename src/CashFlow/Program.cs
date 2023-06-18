using CashFlow.Application.Configuration.Data;
using CashFlow.Application.Configuration.Extensions;
using CashFlow.Domain;
using CashFlow.Infrastructure.Database;
using CashFlow.Infrastructure.Domain.Movement;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContexts(builder.Configuration);

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<SeedData>();

builder.Services.AddScoped<IMovementRepository, MovementRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovementContext>();
    await context.Database.MigrateAsync();
    var service = scope.ServiceProvider.GetService<SeedData>();
    service?.Seed();
}

await app.RunAsync();


public partial class Program { }
