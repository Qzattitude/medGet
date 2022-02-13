using medGet.Database;
using medGet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;

namespace medGet.Controllers
{
    public class BulkAddController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BulkAddController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MedicineDetails> objList = _db.MedicineDetails;
            return View(objList);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Insert(String Path)
        {
            using (var streamReader = new StreamReader(Path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<MedicineDetailsMap>();
                    var records = csvReader.GetRecords<dynamic>().ToList();
                    

                }
            }
            return RedirectToAction("Index");
        }
        public class MedicineDetailsMap : ClassMap<MedicineDetails>
        {
            public MedicineDetailsMap()
            {
                Map(m => m.Id).Name("id");
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
