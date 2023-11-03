using Microsoft.EntityFrameworkCore;

namespace StockAppApi.Models
{
    public class StockAppContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<RealtimeQuote> RealTimeQuotes { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CoveredWarrant> CoveredWarrants { get; set; }
        public StockAppContext(DbContextOptions<StockAppContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WatchList>().HasKey(w => new { w.userid, w.stockid });
            modelBuilder.Entity<Order>().ToTable(table => table.HasTrigger("trigger_orders"));
        }
    }
}
