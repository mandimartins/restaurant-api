using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModel;
using Restaurant.Data.ViewModels;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Controllers
{
    [Route("api/menuitem")]
    [ApiController]
    [Authorize]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly INotificationHandler _notificationHandler;
        public MenuItemController(
            IMenuItemService menuService,
            INotificationHandler notificationHandler)
        {
            _menuItemService = menuService;
            _notificationHandler = notificationHandler;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MenuItemViewModel menuItem)
        {
            try
            {
                var response = await _menuItemService.AddAsync(menuItem);

                if (!_notificationHandler.Messages().IsNullOrEmpty())
                    return BadRequest(_notificationHandler.Messages());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var response = await _menuItemService.GetAsyncAsNoTracking(Id);

                if (!_notificationHandler.Messages().IsNullOrEmpty())
                    return BadRequest(_notificationHandler.Messages());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }

        [HttpPost("getall")]
        public async Task<IActionResult> GetAll([FromBody] GridFilterViewModel filter)
        {
            try
            {
                (int total, IList<MenuItem> data) = await _menuItemService.GetAllAsyncAsNoTracking(filter);

                return Ok(new { total, data });
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return Ok(await _menuItemService.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }

    }
}
