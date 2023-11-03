using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public interface ICoveredWarrantsRepository
    {
        Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId);
    }
}
