using medGet.Models.Cart;

namespace medGet.ViewModels
{
    public class PreviousOrderViewModel
    {
        //public Guid CartId { get; set; }
        //public string BrandName { get; set; }
        //public float Price { get; set; }
        //public int Quantity { get; set; }
        //public float TotalCost { get; set; }
        //public DateTime OrderDate { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
    }
}
