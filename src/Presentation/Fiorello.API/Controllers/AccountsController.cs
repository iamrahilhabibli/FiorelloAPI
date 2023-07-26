using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public AccountsController(IAuthService authService, SignInManager<IdentityUser> signInManager, AppDbContext context, IJwtService jwtService)
        {
            _authService = authService;
            _signInManager = signInManager;
            _context = context;
            _jwtService = jwtService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            await _authService.Register(registerDto);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(SignInDto signInDto)
        {
            TokenResponseDto tokenResponse = await _authService.Login(signInDto);
            return Ok(tokenResponse);
        }
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshToken([FromQuery] string token)
        {
            var response = await _authService.ValidateRefreshToken(token);
            return Ok(response);
        }

    }
}
