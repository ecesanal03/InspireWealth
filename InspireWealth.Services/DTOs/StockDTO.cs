using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InspireWealth.Services.DTOs
{
    public class StockDTO : IEntityDTO
    {
        public string Id { get; set; } = String.Empty;
        public string Symbol { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public decimal CurrentPrice { get; set; } = 0;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
