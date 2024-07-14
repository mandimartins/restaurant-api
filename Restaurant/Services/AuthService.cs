using Microsoft.AspNetCore.Identity;
using Restaurant.Data.ViewModel;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.ExtensionMethods;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly INotificationHandler _notificationHandler;

        public AuthService(
            UserManager<IdentityUser> userManager, 
            IConfiguration configuration,
            IJwtTokenService jwtTokenService,
            INotificationHandler notificationHandler)
        {
            this._userManager = userManager;
            this._jwtTokenService = jwtTokenService;
            this._notificationHandler = notificationHandler;
        }

        public async Task<bool> SignUpAsync(AuthViewModel signUp)
        {
            if (!signUp.Validate().Notify(_notificationHandler))
                return false;

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

            if (user == null)
            {
                _notificationHandler.AddMessage(new Message() { Title = "Wrong credentials",Content ="Wrong credentials!" });
                return new UserInfoViewModel();
            }

            var isSignedIn = await _userManager.CheckPasswordAsync(user, signIn.Password);

            if (!isSignedIn) throw new Exception("error on login");

            var token = _jwtTokenService.GenerateToken(user);

            return new UserInfoViewModel() { Email = user.Email, UserName = user.UserName, Token = token};
        }
    }
}
