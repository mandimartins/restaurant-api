using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.DTOs;
using Restaurant.Data.ViewModels;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly INotificationHandler _notificationHandler;
        public ProductController(
            IProductService productService,
            INotificationHandler notificationHandler)
        {
            _productService = productService;
            _notificationHandler = notificationHandler;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductViewModel product)
        {
            try
            {
                var response = await _productService.AddAsync(product);

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
                var response = await _productService.GetAsyncAsNoTracking(Id);

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
                (int total, IList<ProductDTO> data) = await _productService.GetAllAsyncAsNoTracking(filter);

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
                return Ok(await _productService.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Message(ex.Message, ex.Message, ex.StackTrace));
            }
        }
    }
}
