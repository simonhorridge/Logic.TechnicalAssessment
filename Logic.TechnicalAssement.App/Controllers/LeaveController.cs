using Logic.TechnicalAssement.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logic.TechnicalAssement.App.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILogger<LeaveController> _logger;
        private readonly IHttpContextAccessor HttpContextAccessor;

        private List<LeaveViewModel> leaveRequests
        {
            get { return null; }
            set { }
        }

        public LeaveController(ILogger<LeaveController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            HttpContextAccessor = httpContextAccessor;            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
