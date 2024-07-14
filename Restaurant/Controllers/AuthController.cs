using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.ViewModel;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly INotificationHandler _notificationHandler;

        public AuthController(IAuthService authService, INotificationHandler notificationHandler)
        {
            this._authService = authService;
            this._notificationHandler = notificationHandler;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SingUp(AuthViewModel signUp)
        {
            try
            {
                var response = await _authService.SignUpAsync(signUp);

                if (!_notificationHandler.Messages().IsNullOrEmpty())
                    return BadRequest(_notificationHandler.Messages());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SingIn(AuthViewModel signIn)
        {
            try
            {
                var response = await _authService.SignInAsync(signIn);

                if (!_notificationHandler.Messages().IsNullOrEmpty())
                    return BadRequest(_notificationHandler.Messages());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
