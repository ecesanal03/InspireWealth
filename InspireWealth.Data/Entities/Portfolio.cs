using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspireWealth.Data.Entities
{
    public class Portfolio : IOwnedEntity, IEntity
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
        public decimal AveragePrice { get; set; } = 0;
        [Required]
        public decimal AccountValue { get; private set; } = 0;
        
        public ICollection<PortfolioTransaction> PortfolioTransactions { get; set; } = new List<PortfolioTransaction>();
    }
}
