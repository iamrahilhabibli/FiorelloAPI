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
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CategoryCreateDtoValidator));
//builder.Services.AddAutoMapper(typeof(CategoryProfile).Assembly);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddPersistenceServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
