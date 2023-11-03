using Microsoft.EntityFrameworkCore;
using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public class CoveredWarrantsRepository : ICoveredWarrantsRepository
    {
        private readonly StockAppContext _context;
        public CoveredWarrantsRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId)
        {
            return await _context.CoveredWarrants.Where(CW => CW.UnderlyingAssetId == stockId).
                Include(cw => cw.Stock).ToListAsync();
        }
    }
}
