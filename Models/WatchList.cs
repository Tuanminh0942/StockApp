using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppApi.Models
{
    [Table("WATCHLISTS")]
    public class WatchList
    {
        [Key]
        [ForeignKey("USERS")]
        [Column("user_id")]
        public int? userid { get; set; }

        [Key]
        [ForeignKey("STOCKS")]
        [Column("stock_id")]
        public int? stockid { get; set; }

        public User? user { get; set; }
        public Stock? stock { get; set; }
    }
}

