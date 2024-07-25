using InspireWealth.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InspireWealth.Services.DTOs
{
    /// <summary>
    /// Entities: Entities represent domain objects or database tables. They encapsulate data and state that need to be persisted. 
    /// AKA Data Transfer Objects (DTOs)
    /// </summary>
    public class PortfolioTransactionDTO : IEntityDTO, IOwnedDTO
    {
        public string Id { get; set; } = String.Empty;

        public string UserId { get; set; } = String.Empty;

        public string PortfolioId { get; set; } = String.Empty;

        public string StockId { get; set; } = String.Empty;

        public string TradeId { get; set; } = String.Empty;

        public int Quantity { get; set; } = 0;

        public decimal Price { get; set; } = 0;

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public TradeTypeEnum TradeType { get; set; }
    }
}
