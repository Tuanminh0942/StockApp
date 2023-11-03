using StockAppApi.Models;
using StockAppApi.Repositories;

namespace StockAppApi.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public async Task<List<RealtimeQuote>?> GetRealTimeQuotes(int Page, int Limit, string sector, string industry)
        {
            return await _quoteRepository.GetRealTimeQuotes(Page, Limit, sector, industry);
        }

        public async Task<List<Quote>> GetHistoricalQuotes(int Days, int stockId)
        {
            return await _quoteRepository.GetHistoricalQuote(Days, stockId);
        }
    }
}
