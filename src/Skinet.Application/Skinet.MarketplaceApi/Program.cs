using Microsoft.EntityFrameworkCore;
using Skinet.CrossCutting.InversionOfControl;
using Skinet.Data.Database;
using Skinet.Domain.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServerRepositoryDependency();
builder.Services.AddTransient<SkinetContext>();

var app = builder.Build();

// Apply migrations and create the database on startup logging any errors.
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<SkinetContext>();
using var logger = scope.ServiceProvider.GetService<ILoggerFactory>();
if (db is not null && logger is not null)
{
    await db.Database.MigrateAsync();
    await SkinetContextSeed.SeedAsync(db, logger);
}
else
{
    throw new DbScopeException("Database scope for startup is null!");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();