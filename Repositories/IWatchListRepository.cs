using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public interface IWatchListRepository
    {
        Task AddStocktoWatchList(int userId, int stockId);
        Task<WatchList?> GetWatchList(int userId, int stockId);
        Task<List<Stock?>?> GetWatchListByUserId(int userId);
    }
}
