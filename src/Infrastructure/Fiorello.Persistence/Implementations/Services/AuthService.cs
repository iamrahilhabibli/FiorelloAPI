﻿using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Entities;
using Fiorello.Domain.Enums;
using Fiorello.Persistence.Contexts;
using Fiorello.Persistence.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using UnionArchitecture.Persistence.Exceptions;

namespace Fiorello.Persistence.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityUser> _roleManager;
    private readonly IJwtService _jwtService;
    private readonly AppDbContext _context;
    public AuthService(UserManager<AppUser> userManager,
                      SignInManager<AppUser> signinManager,
                      RoleManager<IdentityUser> roleManager,
                      IJwtService jwtService,
                      AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signinManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
        _context = context;
    }

    public async Task Register(RegisterDto registerDTO)
    {
        AppUser appUser = new()
        {
            FullName = registerDTO.fullname,
            UserName = registerDTO.username,
            Email = registerDTO.email,
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
    public async Task<TokenResponseDto> Login(SignInDto signInDto)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(signInDto.UsernameOrEmail);
        if (appUser is null)
        {
            appUser = await _userManager.FindByNameAsync(signInDto.UsernameOrEmail);
            if (appUser is null)
            {
                throw new SignInFailureException("Invalid Login");
            }
        }

        SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, signInDto.password, true);
        if (!signInResult.Succeeded)
        {
            throw new SignInFailureException("Invalid Login");
        }

        if (!appUser.IsActive)
        {
            throw new SignInFailureException("User is inactive. Please contact support.");
        }
        TokenResponseDto tokenResponse = _jwtService.CreateJwtToken(appUser);
        return tokenResponse;
    }
    public async Task<TokenResponseDto> ValidateRefreshToken(string refreshToken)
    {
        if (refreshToken is null)
        {
            throw new ArgumentNullException("Refresh token does not exist");
        }
        AppUser? appUser = await _context.Users.Where(u => u.RefreshToken == refreshToken).FirstOrDefaultAsync();
        if (appUser is null)
        {
            throw new ArgumentNullException("User does not exist");
        }
        if (appUser.RefreshTokenExpiration < DateTime.UtcNow)
        {
            throw new ArgumentNullException("Refresh token does not exist");
        }
        TokenResponseDto tokenResponse = _jwtService.CreateJwtToken(appUser);
        appUser.RefreshToken = tokenResponse.refreshToken;
        appUser.RefreshTokenExpiration = tokenResponse.refreshTokenExpiration;
        await _userManager.UpdateAsync(appUser);

        return tokenResponse;
    }
}
