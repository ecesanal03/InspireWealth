using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspireWealth.Data.Entities
{
    public class PortfolioTransaction : IEntity, IOwnedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string UserId { get; set; } = String.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!; // Navigation property

        [Required]
        public string PortfolioId { get; set; } = String.Empty;
        
        [ForeignKey("PortfolioId")]
        public Portfolio Portfolio { get; set; } = null!; // Navigation property

        [Required]
        public string StockId { get; set; } = String.Empty;

        [ForeignKey("StockId")]
        public Stock Stock { get; set; } = null!; // Navigation property

        [Required]
        public string TradeId { get; set; } = String.Empty;

        [ForeignKey("TradeId")]
        public Trade Trade { get; set; } = null!; // Navigation property

        [Required]
        public int Quantity { get; set; } = 0;
        
        [Required]
        public decimal Price { get; set; } = 0;
        
        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required]
        public TradeTypeEnum TradeType { get; set; }
    }
}
