using StockAppApi.Models;

namespace StockAppApi.Services
{
    public interface IStockService
    {
        Task<Stock?> GetStockById(int StockId);
    }
}
