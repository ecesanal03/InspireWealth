using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Services.DTOs
{
    public class MarketDataDTO : IEntityDTO
    {
        public string Id { get; set; } = String.Empty;
        public string Symbol { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public decimal CurrentPrice { get; set; } = 0;
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
