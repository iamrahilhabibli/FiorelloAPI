using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Entities;

namespace Fiorello.Application.Abstraction.Services
{
    public interface IJwtService
    {
        TokenResponseDto CreateJwtToken(AppUser appUser);
    }
}
