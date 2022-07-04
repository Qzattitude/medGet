using FastReport.Data;
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
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\OrderReport.frx";
            web.Report.Load(path);
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = mssqlDataConnection.ConnectionString;
            web.Report.SetParameterValue("CONN", Conn);
            web.Report.SetParameterValue("UserName", currentuser);
            web.Report.SetParameterValue("OrderStatus", 0);
            web.Report.SetParameterValue("TotalCost", Math.Round(amount, 2));
            return View(web);
        }
    }
}
