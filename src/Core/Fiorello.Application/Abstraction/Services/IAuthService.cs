using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Application.Abstraction.Services;

public interface IAuthService
{
    Task Register(RegisterDto registerDTO);
    Task<TokenResponseDto> ValidateRefreshToken(string refreshToken);
    Task<TokenResponseDto> Login(SignInDto signInDto);
}
