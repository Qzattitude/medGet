using System;
using FastReport;
using medGet.Controllers.DbController;
using medGet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using medGet.Models.Cart;
using Microsoft.AspNetCore.Authorization;

namespace medGet.Controllers
{
    public class PaymentController : Controller
    {
        private readonly AppDbContext Db;

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment HostingEnvironment { get; }
        private readonly string wwwrootDirectory =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Notice/Reports/");

        public PaymentController(AppDbContext db,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            Db = db;
            HostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "User")]
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
            //return RedirectToAction("Index","Order");
            return View();
        }

        #region Waste of Time
        //public FileResult Generate()
        //{
        //    FastReport.Utils.Config.WebMode = true;
        //    Report report = new Report();
        //    string webRootPath = HostingEnvironment.WebRootPath;
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Reports/PaymentReport.frx");
        //    report.Load(path);

        //    var context = Db.OrderProduct.Where(p => p.OrderStatus.Equals(false)).AsQueryable();
        //    var pricelist = context.Select(q => q.TotalCostProduct).ToList();
        //    double amount = 0.0d;
        //    PaymentViewModel model = new PaymentViewModel();
        //    OrderProduct orderProduct = new OrderProduct();
        //    foreach (var cost in pricelist)
        //    {
        //        amount += cost;
        //    }
        //    model.TotalAmount = Math.Round(amount, 2);
        //    model.Products = context.ToList();
        //    report.SetParameterValue("TotalCost", Math.Round(amount, 2));
        //    report.RegisterData(orderProduct );

        //    if (report.Report.Prepare())
        //    {
        //        FastReport.Export.PdfSimple.PDFSimpleExport pdfExport =
        //            new FastReport.Export.PdfSimple.PDFSimpleExport();
        //        pdfExport.ShowProgress = false;
        //        pdfExport.Subject = "Subject Report";
        //        pdfExport.Title = "Report Title";
        //        MemoryStream ms = System.IO.MemoryStream();
        //        report.Report.Export(pdfExport, ms);
        //        report.Dispose();
        //        pdfExport.Dispose();
        //        ms.Position = 0;
        //        return File(ms, "application/pdf", "myreport.pdf");

        //    }
        //    else
        //    {
        //        retun null;
        //    }

        //}
        #endregion
    }
}
