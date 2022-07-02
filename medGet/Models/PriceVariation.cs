using System.ComponentModel.DataAnnotations;

namespace medGet.Models
{
    public class PriceVariation
    {
        [Key]
        public Guid Id { get; set; }
        public float Price { get; set; }
        public string DAR { get; set; }
    }
}
