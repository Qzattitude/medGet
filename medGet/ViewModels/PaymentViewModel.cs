
using medGet.Models;
using medGet.Models.Cart;

namespace medGet.ViewModels
{
    public class PaymentViewModel
    {
        public double TotalAmount { get; set; }
        public List<OrderProduct> Products { get; set; }
    }
}
