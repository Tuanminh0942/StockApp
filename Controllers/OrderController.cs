using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppApi.Attribute;
using StockAppApi.Extensions;
using StockAppApi.Services;
using StockAppApi.ViewModel;

namespace StockAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }
        [HttpPost("place_order")]
        [JwtAuthorize]
        public async Task<IActionResult> PlaceOrder(OrderViewModel orderViewModel)
        {
            int UserId = HttpContext.GetUserId();
            var user = await _userService.GetByID(UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            orderViewModel.UserId = UserId;
            var createOrder = await _orderService.PlaceOrder(orderViewModel);
            return Ok(createOrder); 
        }
    }
}
