using FastReport.Data;
using FastReport.Utils;
using FastReport.Web;
using medGet.Controllers.DbController;
using medGet.Models;
using medGet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace medGet.Controllers
{
    public class ReportController : Controller
    {
        private static readonly string ReportsFolder = FindReportsFolder();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ReportController(IWebHostEnvironment webHostEnvironment, 
            AppDbContext db, 
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private static string FindReportsFolder()
        {
            string fReportsFolder = "";
            string thisFolder = Config.ApplicationFolder;

            for (int i = 0; i < 6; i++)
            {
                string dir = Path.Combine(thisFolder, "Reports");
                if (Directory.Exists(dir))
                {
                    string rep_dir = Path.GetFullPath(dir);
                    if (System.IO.File.Exists(Path.Combine(rep_dir, "reports.xml")))
                    {
                        fReportsFolder = rep_dir;
                        break;
                    }
                }
                thisFolder = Path.Combine(thisFolder, @"..");
            }
            return fReportsFolder;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCartByUserNameAndOrderSatus()
        {
            var context = _db.OrderProduct.Where(p => p.OrderStatus.Equals(false)).AsQueryable();
            var currentuser = _userManager.GetUserName(HttpContext.User);
            var pricelist = context.Select(q => q.TotalCostProduct).ToList();
            double amount = 0.0d;
            PaymentViewModel model = new PaymentViewModel();
            foreach (var cost in pricelist)
            {
                amount += cost;
            }

            WebReport web = new WebReport();
            //var path = $"{this._webHostEnvironment.WebRootPath}\\wwwroot\\Reports\\OrderReport.frx";
            web.Report.Load(Path.Combine(ReportsFolder, $"OrderReport.frx"));
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = mssqlDataConnection.ConnectionString;
            web.Report.SetParameterValue("CONN", Conn);
            web.Report.SetParameterValue("UserName", currentuser);
            web.Report.SetParameterValue("OrderStatus", 0);
            web.Report.SetParameterValue("TotalCost", Math.Round(amount, 2));
            return View(web);
        }

        //private WebReport GenerateReportViewModel<T>(IEnumerable<T> reportableDataSet)
        //{
        //    var model = new WebReport();

        //    var reportToLoad = model.ReportName;
        //    model.Report.Load(Path.Combine(ReportsFolder, $"{reportToLoad}.frx"));
        //    model.Report.RegisterData(reportableDataSet, $"{model.ReportName}s");
        //    model.Report.GetDataSource($"{model.ReportName}s").Enabled = true;
        //    model.Report.Prepare();
        //    return model;
        //}
        //private WebReport GenerateReportViewModel<T>(IEnumerable<T> reportableDataSet, string templateName)
        //{
        //    var model = new WebReport();

        //    var reportToLoad = templateName;
        //    model.Report.Load(Path.Combine(ReportsFolder, $"{reportToLoad}.frx"));
        //    model.Report.RegisterData(reportableDataSet, $"{model.ReportName}s");
        //    model.Report.GetDataSource($"{model.ReportName}s").Enabled = true;
        //    model.Report.Prepare();
        //    return model;
        //}
    }
}
