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
                return Ok(await _menuService.GetAllAsyncAsNoTracking());
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }

        [HttpGet("getmenuitens/{id}")]
        public async Task<IActionResult> GetMenuItens(int id)
        {
            try
            {
                var response = await _menuService.GetAllMenuItensByIdMenuAsNoTracking(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }
    }
}
