using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Data.Entities
{
    public class MarketData : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string StockId { get; set; } = String.Empty;

        [ForeignKey("StockId")]
        public Stock Stock { get; set; } = null!; // Navigation property

        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public decimal High { get; set; } 
        public decimal Low { get; set; } 
        public decimal Open { get; set; } 
        public decimal Close { get; set; } 
        public int Volume { get; set; } 
        public decimal Change { get; set; } 
        public decimal ChangePercent { get; set; } 
        public decimal MarketCap { get; set; } 
        public decimal PE { get; set; } 
        public decimal WeekHigh52 { get; set; }
        public decimal WeekLow52 { get; set; } 

    }
}
