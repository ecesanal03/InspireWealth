using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspireWealth.Data.Entities
{
    public class Trade : IOwnedEntity, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string UserId { get; set; } = String.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!; // Navigation property

        [Required]
        public string StockId { get; set; } = String.Empty;

        [ForeignKey("StockId")]
        public Stock Stock { get; set; } = null!; // Navigation property

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        public decimal TradeProfit { get; set; } = 0;

        // need to get these from the stock entity's current price when the trade is made
        public decimal BuyPrice { get; set; } = 0;
        public decimal SellPrice { get; set; } = 0;

        [Required]
        public DateTime TradeDate { get; set; } = DateTime.Now;

        [Required]
        public TradeTypeEnum TradeType { get; set; } 
    }

}
