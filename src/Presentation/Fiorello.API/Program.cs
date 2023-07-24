using Fiorello.Application.Validators.CategoryValidators;
using Fiorello.Persistence.Contexts;
using Fiorello.Persistence.ExtensionMethods;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Fiorello.Persistence.MapperProfiles;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Persistence.Implementations.Repositories;
using Fiorello.Persistence.Implementations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices();


builder.Services.AddScoped<AppDbContextInitializer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var instance = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
    await instance.InitializerAsync();
    await instance.RoleSeedAsync();
    await instance.UserSeedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
