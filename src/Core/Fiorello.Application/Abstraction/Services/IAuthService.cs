using Fiorello.Application.DTOs.Auth;

namespace Fiorello.Application.Abstraction.Services;

public interface IAuthService
{
    Task Register(RegisterDTO registerDTO);
}
