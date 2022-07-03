using CsvHelper;
using CsvHelper.Configuration;
using medGet.Controllers.DbController;
using medGet.Models;
using medGet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            SearchViewModel model = new SearchViewModel();
            model.MedicineDetails = await _db.PriceVariation
                .Where(p=> !p.Price.Equals(0)).Take(10).ToListAsync();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(SearchViewModel model)
        { 
            if (ModelState.IsValid && !model.Text.Equals(null))
            {
                model.MedicineDetails = await _db.PriceVariation.Where(p => (p.BrandName.Contains(model.Text)
                            || p.CompanyName.Contains(model.Text)
                            || p.DAR.Contains(model.Text)
                            || p.GenericElements.Contains(model.Text))
                            && !p.Price.Equals(0)).ToListAsync();
                return View(model);
            }
            else
            return RedirectToAction("Index","Search");
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Insert(String Path)
        {
            var ExistingData = await _db.MedicineDetails.ToListAsync();
            if (ExistingData.Count != 0)
            {
                return RedirectToAction("Index");
            }
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var streamReader = new StreamReader(Path))
            {
                using var csvReader = new CsvReader(streamReader, config);
                csvReader.Context.RegisterClassMap<MedicineDetailsMap>();
                var records = csvReader.GetRecords<MedicineDetails>().ToList();
                await _db.MedicineDetails.AddRangeAsync(records);
                await _db.SaveChangesAsync();
            }


            IEnumerable<MedicineDetails> medicineDetails = await _db.MedicineDetails.ToListAsync();
            foreach (var element in medicineDetails)
            {
                var PriceVariationCount = element.Price.Split(", ").Count();
                if (PriceVariationCount == 1)
                {
                    PriceVariation priceVariation = new()
                    {
                        Id = Guid.NewGuid(),
                        DAR = element.DAR,
                        Price = float.Parse(element.Price),
                        BrandName = element.BrandName,
                        CompanyName = element.CompanyName,
                        GenericElements = element.Generic,
                        ElementsQuantity = element.Strength,
                        MedicineType = element.Dosages,
                        UsedFor = element.UsedFor
                    };
                    await _db.AddAsync(priceVariation);

                }
                else
                {
                    List<string> SegregatedPrice = element.Price.Split(", ").ToList();
                    foreach (var segreg in SegregatedPrice)
                    {
                        PriceVariation priceVariation = new()
                        {
                            Id = Guid.NewGuid(),
                            DAR = element.DAR,
                            Price = float.Parse(segreg),
                            BrandName = element.BrandName,
                            CompanyName = element.CompanyName,
                            GenericElements = element.Generic,
                            ElementsQuantity = element.Strength,
                            MedicineType = element.Dosages,
                            UsedFor = element.UsedFor
                        };
                        await _db.AddAsync(priceVariation);
                    }
                }
            }
            await _db.SaveChangesAsync();
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
