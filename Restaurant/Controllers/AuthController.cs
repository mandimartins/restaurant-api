using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.ViewModel;
using Restaurant.Services.Interfaces;

namespace Restaurant.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SingUp(AuthViewModel signUp)
        {
            try
            {
                return Ok(await _authService.SignUpAsync(signUp));
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
                return Ok(await _authService.SignInAsync(signIn));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
