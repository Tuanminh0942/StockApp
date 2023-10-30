using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly StockAppContext _context;
        public StockRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task<Stock?> GetStockById(int StockId)
        {
            return await _context.Stocks.FindAsync(StockId);
        }
    }
}
