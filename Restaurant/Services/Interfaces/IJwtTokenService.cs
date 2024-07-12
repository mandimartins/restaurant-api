using Microsoft.AspNetCore.Identity;

namespace Restaurant.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(IdentityUser user);
    }
}
