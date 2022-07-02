using medGet.Models;

namespace medGet.ViewModels
{
    public class ProductViewModel
    {
        public Guid Product { get; set; }
        public IDictionary<string, string>? Generic_Quantity { get; set; }
        public PriceVariation? MedicineDetails { get; set; }
    }
}
