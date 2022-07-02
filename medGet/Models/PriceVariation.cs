using System.ComponentModel.DataAnnotations;

namespace medGet.Models
{
    public class PriceVariation
    {
        [Key]
        public Guid Id { get; set; }
        public float Price { get; set; }
        public string DAR { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public string GenericElements { get; set; }
        public string ElementsQuantity { get; set; }
        public string MedicineType { get; set; }
        public string UsedFor { get; set; }
    }
}
