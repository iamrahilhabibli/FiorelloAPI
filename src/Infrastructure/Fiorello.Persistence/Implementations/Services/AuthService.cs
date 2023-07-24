using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.Auth;
using Fiorello.Domain.Entities;
using Fiorello.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Text;
using UnionArchitecture.Persistence.Exceptions;

namespace Fiorello.Persistence.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _siginManager;
    private readonly RoleManager<IdentityUser> _roleManager;
    public AuthService(UserManager<AppUser> userManager,
                      SignInManager<AppUser> siginManager,
                      RoleManager<IdentityUser> roleManager)
    {
        _userManager = userManager;
        _siginManager = siginManager;
        _roleManager = roleManager;
    }

    public async Task Register(RegisterDTO registerDTO)
    {
        AppUser appUser = new()
        {
            FullName = registerDTO.Fullname,
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
            IsActive = false
        };

        IdentityResult identityResult = await _userManager.CreateAsync(appUser,registerDTO.password);
        if (!identityResult.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in identityResult.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }

        var result = await _userManager.AddToRoleAsync(appUser, Role.Member.ToString());
        if (!result.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in result.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }
    }
}
