using medGet.Models.Cart;

namespace medGet.ViewModels
{
    public class PreviousOrderViewModel
    {
        public Guid CartId { get; set; }
        public double TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
    }
}
