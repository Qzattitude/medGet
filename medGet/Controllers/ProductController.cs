using medGet.Controllers.DbController;
using medGet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medGet.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext Db;

        public ProductController(AppDbContext db)
        {
            Db = db;
        }
        [HttpGet]
        public IActionResult Index(string Id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProductViewModel model, Guid Id)
        {
            if (ModelState.IsValid && !Id.Equals(null))
            {
                model.MedicineDetails = await Db.PriceVariation
                    .Where(p => p.Id.Equals(Id))
                    .FirstOrDefaultAsync();
                var GElement = model.MedicineDetails.GenericElements.ToString();
                var QElement = model.MedicineDetails.ElementsQuantity.ToString();
                if(GElement.Length.Equals(QElement.Length) && !GElement.Equals(null) && !QElement.Equals(null))
                {
                    model.Generic_Quantity = ElementSplitter(GElement, QElement);
                    return View(model);
                }
                
            }
            return RedirectToAction("Index", "Search");
        }

        public Dictionary<string,string> ElementSplitter(string ElementString, string ElementQuantity)
        {
            string ElementSplitter = " + ";
            string QuantitySplitter = " + ";

            IList<string> ElementList = ElementString.Split(ElementSplitter);
            IList<string> QuantityList = ElementQuantity.Split(QuantitySplitter);
            Dictionary<string, string>? ElementVsQuantity = new Dictionary<string, string>();
            if (ElementList.Count.Equals(QuantityList.Count))
            {
                int loopelement = 0;
                var TotalElements = ElementList.Count;
                foreach (string Element in ElementList)
                {
                    ElementVsQuantity.Add(Element, QuantityList[loopelement]);
                    loopelement++;
                }
                return ElementVsQuantity;

            }
            return ElementVsQuantity;
        }
    }
}
