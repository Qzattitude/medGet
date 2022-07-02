using medGet.Models;

namespace medGet.ViewModels
{
    public class ProductViewModel
    {
        public Guid Product { get; set; }
        public string BrandName { get; set; }
        public string MedicineType { get; set; }
        public string CompanyName { get; set; }
        public string GenericElements { get; set; }
        public string ElementsQuantity { get; set; }
        public IDictionary<string, string> Generic_Quantity { get; set; }
        public string UsedFor { get; set; }
        public string DAR { get; set; }
        public PriceVariation PriceVariation { get; set; }
    }
}
