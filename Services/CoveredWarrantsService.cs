using StockAppApi.Models;
using StockAppApi.Repositories;

namespace StockAppApi.Services
{
    public class CoveredWarrantsService : ICoveredWarrantsService
    {
        private readonly ICoveredWarrantsRepository _cwRepository;
        public CoveredWarrantsService(ICoveredWarrantsRepository cwRepository)
        {
            _cwRepository = cwRepository;
        }

        public async Task<List<CoveredWarrant>> GetCoveredWarrantByStockId(int stockId)
        {
            return await _cwRepository.GetCoveredWarrantsByStockId(stockId);
        }
    }
}
