using medGet.Models.Cart;

namespace medGet.ViewModels
{
    public class AdminSaleViewModel
    {
        public double TotalEarning { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
    }
}
