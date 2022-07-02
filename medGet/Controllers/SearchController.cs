using CsvHelper;
using CsvHelper.Configuration;
using medGet.Controllers.DbController;
using medGet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace medGet.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _db;

        public SearchController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MedicineDetails> objList = _db.MedicineDetails
                .Take(10);
            return View(objList);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                IEnumerable<MedicineDetails> objList = _db.MedicineDetails
                    .Where(p => (p.BrandName.Contains(text)
                            || p.CompanyName.Contains(text)
                            || p.DAR.Contains(text)
                            || p.Generic.Contains(text))
                            && !p.Price.Contains("0"));
                return View(objList);
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(String Path)
        {
            //var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            //{
            //    HeaderValidated = null,
            //    MissingFieldFound = null
            //};

            //using (var streamReader = new StreamReader(Path))
            //{
            //    using var csvReader = new CsvReader(streamReader, config);
            //    csvReader.Context.RegisterClassMap<MedicineDetailsMap>();
            //    var records = csvReader.GetRecords<MedicineDetails>().ToList();
            //    _db.MedicineDetails.AddRange(records);
            //    _db.SaveChanges();
            //}

            
            //IEnumerable<MedicineDetails> medicineDetails = _db.MedicineDetails.ToList();
            //foreach (var element in medicineDetails)
            //{
            //    var PriceVariationCount = element.Price.Split(", ").Count();
            //    if (PriceVariationCount == 1)
            //    {
            //        PriceVariation priceVariation = new ()
            //        {
            //            Id = Guid.NewGuid(),
            //            DAR = element.DAR,
            //            Price = float.Parse(element.Price)
            //        };
            //        _db.Add(priceVariation);
                    
            //    }
            //    else
            //    {
            //        List<string> SegregatedPrice = element.Price.Split(", ").ToList();
            //        foreach(var segreg in SegregatedPrice)
            //        {
            //            PriceVariation priceVariation = new ()
            //            {
            //                Id = Guid.NewGuid(),
            //                DAR = element.DAR,
            //                Price = float.Parse(segreg)
            //            };
            //            _db.Add(priceVariation);
            //        }
            //    }
            //}
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }

        public class MedicineDetailsMap : ClassMap<MedicineDetails>
        {
            public MedicineDetailsMap()
            {
                Map(m => m.CompanyName).Name("name").ToString();
                Map(m => m.BrandName).Name("brand").ToString();
                Map(m => m.Generic).Name("generic").ToString();
                Map(m => m.Strength).Name("strength").ToString();
                Map(m => m.Dosages).Name("dosages").ToString();
                Map(m => m.Price).Name("price").ToString();
                Map(m => m.UsedFor).Name("usedfor").ToString();
                Map(m => m.DAR).Name("dar").ToString();
            }
        }
    }
}
