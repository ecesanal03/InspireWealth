using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InspireWealth.Services.DTOs
{
    public class PortfolioDTO : IOwnedDTO, IEntityDTO
    {
        public string Id { get; set; } = String.Empty;

        public string UserId { get; set; } = String.Empty;
  
        public string StockId { get; set; } = String.Empty;

        public int Quantity { get; set; } = 0;

        public decimal AveragePrice { get; set; } = 0;

        public decimal AccountValue { get; private set; } = 0;

        public ICollection<PortfolioTransactionDTO> PortfolioTransactions { get; set; } = new List<PortfolioTransactionDTO>();


    }
}
