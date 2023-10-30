using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public interface IStockRepository
    {
        Task<Stock?> GetStockById(int StockId);
    }
}
