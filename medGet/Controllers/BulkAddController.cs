using medGet.Database;
using medGet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;



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
                    var records = csvReader.GetRecords<dynamic>().ToList();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
