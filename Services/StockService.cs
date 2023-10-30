using StockAppApi.Models;
using StockAppApi.Repositories;

namespace StockAppApi.Services
{
    public class StockService : IStockService
    {
        private IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository) 
        {
            _stockRepository = stockRepository;
        }
        public async Task<Stock?> GetStockById(int StockId)
        {
            return await _stockRepository.GetStockById(StockId);
        }
    }
}
