using Microsoft.EntityFrameworkCore;
using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly StockAppContext _context;
        private readonly IConfiguration _configuration;
        public WatchListRepository(StockAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task AddStocktoWatchList(int userId, int stockId)
        {
            var watchlist = await _context.WatchLists.FindAsync(userId, stockId);
            if (watchlist == null)
            {
                watchlist = new WatchList
                {
                    userid = userId,
                    stockid = stockId
                };
                _context.WatchLists.Add(watchlist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<WatchList?> GetWatchList(int userId, int stockId)
        {
            return await _context.WatchLists.FirstOrDefaultAsync(W => W.userid == userId && W.stockid == stockId);
        }
    }
}
