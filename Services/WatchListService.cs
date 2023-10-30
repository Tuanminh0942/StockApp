using StockAppApi.Models;
using StockAppApi.Repositories;

namespace StockAppApi.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _repository;
        public WatchListService(IWatchListRepository repository)
        {
            _repository = repository;
        }

        public async Task AddtoWatchList(int Userid, int Stockid)
        {
            await _repository.AddStocktoWatchList(Userid, Stockid);
        }

        public async Task<WatchList?> GetWatchList(int Userid, int Stockid)
        {
            return await _repository.GetWatchList(Userid, Stockid);
        }
    }
}
