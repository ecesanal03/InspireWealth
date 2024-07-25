using InspireWealth.Data.Entities;

namespace InspireWealth.Services.DTOs
{
    public class TradeDTO : IOwnedDTO, IEntityDTO
    {
        public string Id { get; set; } = String.Empty;
        public string UserId { get; set; } = String.Empty;
        public string StockId { get; set; } = String.Empty;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public DateTime TradeDate { get; set; } = DateTime.Now;
        public TradeTypeEnum TradeType { get; set; }
    }
}
