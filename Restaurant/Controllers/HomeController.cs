using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly INotificationHandler _notificationHandler;
        public HomeController(
            IMenuService menuService,
            INotificationHandler notificationHandler)
        {
            _menuService = menuService;
            _notificationHandler = notificationHandler;
        }


        [HttpGet("getmenus")]
        public async Task<IActionResult> GetMenus()
        {
            try
            {
                var response = await _menuService.GetAllAsyncAsNoTracking();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }
    }
}
