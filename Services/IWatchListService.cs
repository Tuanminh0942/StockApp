using StockAppApi.Models;

namespace StockAppApi.Services
{
    public interface IWatchListService
    {
        Task AddtoWatchList(int Userid, int Stockid);
        Task<WatchList?> GetWatchList(int Userid, int Stockid);
    }
}
