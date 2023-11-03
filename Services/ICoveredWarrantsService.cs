using StockAppApi.Models;

namespace StockAppApi.Services
{
    public interface ICoveredWarrantsService
    {
        Task<List<CoveredWarrant>> GetCoveredWarrantByStockId(int stockId);
    }
}
