using medGet.Models;

namespace medGet.ViewModels
{
    public class SearchViewModel
    {
        public string Text { get; set; }
        public List<PriceVariation>? MedicineDetails { get; set; }
    }
}
