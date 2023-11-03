using StockAppApi.Models;

namespace StockAppApi.Services
{
    public interface IQuoteService
    {
        Task<List<RealtimeQuote>?> GetRealTimeQuotes(int Page,
            int Limit,
            string sector,
            string industry);
        Task<List<Quote>> GetHistoricalQuotes(int days, int stockId);
    }
}
