using System.ComponentModel.DataAnnotations;

namespace medGet.Models.Cart
{
    public class OrderProduct
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public string? UserName { get; set; }
        public int? OrderId { get; set; }
        public bool OrderStatus { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductBrand { get; set; }
        public float Price { get; set; }
        [Range(1, 50, ErrorMessage = "Can only be between 1 to 50")]
        public int Qunatity { get; set; }
        public float TotalCostProduct { get; set; }
        public DateTime DateTime { get; set; }
        public virtual IList<PriceVariation>? PriceVariation { get; set; }
    }
}
