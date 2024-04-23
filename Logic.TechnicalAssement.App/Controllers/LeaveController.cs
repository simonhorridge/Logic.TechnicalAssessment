using Logic.TechnicalAssement.App.Models;
using Logic.TechnicalAssement.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Logic.TechnicalAssement.App.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveRequestService _leaveListService;

        public LeaveController(ILeaveRequestService leaveListService)
        {
            _leaveListService = leaveListService;
        }

        public IActionResult Index()
        {
            return View(new LeaveViewModel());
        }

        [HttpPost]
        public IActionResult SubmitLeave(LeaveViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                //todo - error handling
                _leaveListService.AddLeaveRequest(model);
            }

            return PartialView("_LeaveForm", model);
        }

        public IActionResult LeaveRequests()
        {
            var requests = _leaveListService.LeaveRequests;
            return View(requests);
        }

        public IActionResult LeaveRequestsTable()
        {
            var requests = _leaveListService.LeaveRequests;
            return PartialView("_LeaveRequestsTable", requests);
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
