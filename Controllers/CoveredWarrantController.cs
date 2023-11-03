using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppApi.Services;

namespace StockAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveredWarrantController : ControllerBase
    {
        private readonly ICoveredWarrantsService _cwService;
        public CoveredWarrantController(ICoveredWarrantsService cwService)
        {
            _cwService = cwService;
        }
        [HttpGet("stock/{stockId}")]
        public async Task<IActionResult> GetCoveredWarrantByStockID(int stockId)
        {
            try
            {
                var coveredWarrant = await _cwService.GetCoveredWarrantByStockId(stockId);
                return Ok(coveredWarrant);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
