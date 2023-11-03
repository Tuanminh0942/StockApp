using Microsoft.EntityFrameworkCore;
using StockAppApi.Models;

namespace StockAppApi.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly StockAppContext _context;

        public QuoteRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task<List<RealtimeQuote>?> GetRealTimeQuotes(int Page, int Limit, string sector, string industry)
        {
            var query = _context.RealTimeQuotes.Skip((Page -1)* Limit).Take(Limit);
            if (string.IsNullOrEmpty(sector))
            {
                query = query.Where(q => (q.Sector ?? "").ToLower().Equals(sector.ToLower()));
            }
            if (string.IsNullOrEmpty(industry))
            {
                query = query.Where(q => q.Industry == industry);
            }
            var quotes = await query.ToListAsync();
            return quotes;
        }

        public async Task<List<Quote>> GetHistoricalQuote(int days, int stockid)
        {
            var fromDate = DateTime.Now.Date.AddDays(-days);
            var toDate = DateTime.Now.Date;
            var HistoricalQuotes = await _context.Quotes.Where(q => q.TimeStamp >= fromDate 
                                                                && q.TimeStamp <=toDate 
                                                                && q.StockId == stockid).GroupBy(q => q.TimeStamp.Date).
                                                                Select( q=> new Quote
                                                                {
                                                                    TimeStamp = q.Key,
                                                                    Price = q.Average(q => q.Price),
                                                                }).OrderBy(q => q.TimeStamp).ToListAsync();
            return HistoricalQuotes;

        }
        
    }
}
