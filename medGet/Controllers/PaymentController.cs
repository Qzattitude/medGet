using medGet.Controllers.DbController;
using medGet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace medGet.Controllers
{
    public class PaymentController : Controller
    {
        private readonly AppDbContext Db;

        public PaymentController(AppDbContext db)
        {
            Db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var context = Db.OrderProduct.Where(p => p.OrderStatus.Equals(false)).AsQueryable();
            var pricelist = context.Select(q=> q.TotalCostProduct).ToList();
            double amount = 0.0d;
            PaymentViewModel model = new PaymentViewModel();
            foreach(var cost in pricelist)
            {
                amount += cost;
            }
            model.TotalAmount = Math.Round(amount,2);
            model.Products = context.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Submit()
        {
            var time = DateTime.UtcNow.AddHours(6);
            Db.OrderProduct
                .Where(p => p.OrderStatus.Equals(false))
                .ToList()
                .ForEach(x => x.DateTime=time);
            Db.SaveChanges();
            Db.OrderProduct
                .Where(p => p.OrderStatus.Equals(false))
                .ToList()
                .ForEach(x => x.OrderStatus=true);
            Db.SaveChanges();
            return RedirectToAction("Index","Order");
        }
    }
}
