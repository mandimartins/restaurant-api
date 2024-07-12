using Microsoft.AspNetCore.Identity;
using Restaurant.Data.ViewModel;
using Restaurant.Services.Interfaces;

namespace Restaurant.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            UserManager<IdentityUser> userManager, 
            IConfiguration configuration,
            IJwtTokenService jwtTokenService)
        {
            this._userManager = userManager;
            this._jwtTokenService = jwtTokenService;
        }

        public async Task<bool> SignUpAsync(AuthViewModel signUp)
        {
            var identityUser = new IdentityUser()
            {
                Email = signUp.Email,
                UserName = signUp.UserName
            };

            var registration = await _userManager.CreateAsync(identityUser, signUp.Password);

            return registration.Succeeded;
        }

        public async Task<UserInfoViewModel> SignInAsync(AuthViewModel signIn)
        {
            var user = await _userManager.FindByEmailAsync(signIn.Email);

            if (user == null) throw new Exception("error on login");

            var isSignedIn = await _userManager.CheckPasswordAsync(user, signIn.Password);

            if (!isSignedIn) throw new Exception("error on login");

            var token = _jwtTokenService.GenerateToken(user);

            return new UserInfoViewModel() { Email = user.Email, UserName = user.UserName, Token = token};
        }
    }
}
