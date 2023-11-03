using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public interface IQuoteRepository
    {
        Task<List<RealtimeQuote>?> GetRealTimeQuotes(int Page,
            int Limit,
            string sector,
            string industry);
        Task<List<Quote>> GetHistoricalQuote(int days, int stockid);
    }
}
