using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockAppApi.Attribute;
using StockAppApi.Extensions;
using StockAppApi.Services;
using StockAppWebApi.Filters;
using System.Security.Claims;

namespace StockAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStockService _stockService;
        private readonly IWatchListService _watchListService;
        public WatchListController(IWatchListService watchListService, 
                                   IUserService userService, IStockService stockService)
        {
            _watchListService = watchListService;
            _userService = userService;
            _stockService = stockService;
        }
        [HttpPost("AddStockToWatchList/{Stockid}")]
        [JwtAuthorize]
        public async Task<IActionResult> AddStockToWatchList(int StockId)
        {
            int userId = HttpContext.GetUserId();
            //if(!int.TryParse(_context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            //{
            //    return Unauthorized();
            //}

            //Kiểm tra người dùng và cổ phiếu có tồn tại
            var user = await _userService.GetByID(userId);
            var stock = await _stockService.GetStockById(StockId);
            if(user == null)
            {
                return NotFound("User not found");
            }
            if (stock == null)
            {
                return NotFound("Stock not found");
            }
            //kiểm tra xem cổ phiếu đã tồn tại trong watchlist của người dùng hay chưa
            var existingwatchlistitem = await _watchListService.GetWatchList(userId, StockId);
            {
                if (existingwatchlistitem != null)
                {
                    return BadRequest("stock is already in watchlist");
                }
            }
            await _watchListService.AddtoWatchList(userId,StockId);
            return Ok();
        }
    }
}
