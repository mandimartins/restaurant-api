using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.ViewModel;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly INotificationHandler _notificationHandler;
        public CategoryController(
            ICategoryService categoryService,
            INotificationHandler notificationHandler)
        {
            _categoryService = categoryService;
            _notificationHandler = notificationHandler;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CategoryViewModel category)
        {
            try
            {
                var response = await _categoryService.AddAsync(category);

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
                var response = await _categoryService.GetAsyncAsNoTracking(Id);

                if (!_notificationHandler.Messages().IsNullOrEmpty())
                    return BadRequest(_notificationHandler.Messages());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }
    }
}
