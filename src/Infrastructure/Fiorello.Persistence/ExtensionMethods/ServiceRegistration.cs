using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.Validators.CategoryValidators;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;
using Fiorello.Persistence.Implementations.Repositories;
using Fiorello.Persistence.Implementations.Services;
using Fiorello.Persistence.MapperProfiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiorello.Persistence.ExtensionMethods
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Default"));
            });

            //Validators
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>();


            //AutoMapper
            services.AddAutoMapper(typeof(CategoryProfile).Assembly);

            //Repository
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ISliderReadRepository, SliderReadRepository>();
            services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();

            //Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IJwtService, JwtService>();


            //User 
            services.AddIdentity<AppUser, IdentityRole>(Options =>
            {
                Options.User.RequireUniqueEmail = true;
                Options.Password.RequireNonAlphanumeric = true;
                Options.Password.RequiredLength = 8;
                Options.Password.RequireDigit = true;
                Options.Password.RequireUppercase = true;
                Options.Password.RequireLowercase = true;

                Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                Options.Lockout.MaxFailedAccessAttempts = 3;
                Options.Lockout.AllowedForNewUsers = true;
                //Options.SignIn.RequireConfirmedEmail = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
