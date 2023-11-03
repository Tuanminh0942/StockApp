using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppApi.Models;
using StockAppApi.Services;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace StockAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("ws")]
        public async Task GetRealTimeQuotes(int Page = 1, int limit = 10, string sector = "",
            string industry = "")
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                while(webSocket.State == WebSocketState.Open)
                {
                    List<RealtimeQuote>? quotes = await _quoteService.GetRealTimeQuotes(Page, limit, sector, industry);
                    string jsonString = JsonSerializer.Serialize(quotes);
                    var buffer = Encoding.UTF8.GetBytes(jsonString);
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                    await Task.Delay(2000);
                }
            }
            else
            {

            }
        }
        [HttpGet("Historical")]
        public async Task<IActionResult> GetHistoricalQuotes(int days, int stockId)
        {
            var historicalQuote = await _quoteService.GetHistoricalQuotes(days, stockId);
            return Ok(historicalQuote);
        }
    }
}
