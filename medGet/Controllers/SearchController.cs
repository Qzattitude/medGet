using CsvHelper;
using CsvHelper.Configuration;
using medGet.Controllers.DbController;
using medGet.Models;
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

        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<MedicineDetails> objList = await _db.MedicineDetails.ToListAsync();
            //Change it with Paging
            return View(objList.Take(10));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                IEnumerable<MedicineDetails> objList = await _db.MedicineDetails
                    .Where(p => (p.BrandName.Contains(text)
                            || p.CompanyName.Contains(text)
                            || p.DAR.Contains(text)
                            || p.Generic.Contains(text))
                            && !p.Price.Contains("0")).ToListAsync();
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
        public async Task<IActionResult> InsertAsync(String Path)
        {
            var ExistingData = await _db.MedicineDetails.ToListAsync();
            if ( ExistingData.Count == 0)
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
                        Price = float.Parse(element.Price)
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
                            Price = float.Parse(segreg)
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
