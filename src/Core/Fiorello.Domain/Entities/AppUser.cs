using Microsoft.AspNetCore.Identity;

namespace Fiorello.Domain.Entities;

public class AppUser : IdentityUser
{
    public bool IsActive { get; set; }
    public string? FullName { get; set; }
}
