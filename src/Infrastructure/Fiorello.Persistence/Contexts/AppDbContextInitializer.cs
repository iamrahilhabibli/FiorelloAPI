﻿using Fiorello.Domain.Entities;
using Fiorello.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fiorello.Persistence.Contexts;

public class AppDbContextInitializer
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    public AppDbContextInitializer(AppDbContext context,
                                UserManager<AppUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task InitializerAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task RoleSeedAsync()
    {
        foreach (var role in Enum.GetValues(typeof(Role)))
        {
            if (!await _roleManager.RoleExistsAsync(role.ToString()))
            {
                await _roleManager.CreateAsync(new() { Name = role.ToString() });
            }
        }
    }

    public async Task UserSeedAsync()
    {
        var ByUser = await _userManager.FindByEmailAsync("superadmin@gmail.com");
        if (ByUser is not null) throw new Exception();

        AppUser appUser = new()
        {
            UserName = _configuration["SuperAdminSettings:username"],
            Email = _configuration["SuperAdminSettings:email"]
        };
        await _userManager.CreateAsync(appUser, _configuration["SuperAdminSettings:password"]);
        await _userManager.AddToRoleAsync(appUser, Role.SuperAdmin.ToString());
    }
}
