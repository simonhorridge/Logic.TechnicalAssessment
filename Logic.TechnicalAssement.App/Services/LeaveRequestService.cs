using Logic.TechnicalAssement.App.Models;
using System.Text.Json;

namespace Logic.TechnicalAssement.App.Services
{
    public interface ILeaveRequestService
    {
        List<LeaveViewModel> LeaveRequests { get; }
        void AddLeaveRequest(LeaveViewModel model);
    }

    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveRequestService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<LeaveViewModel> LeaveRequests
        {
            get
            {
                var leaveRequests = _httpContextAccessor.HttpContext.Session.GetString("LeaveRequests");
                return leaveRequests == null
                    ? new List<LeaveViewModel>()
                    : JsonSerializer.Deserialize<List<LeaveViewModel>>(leaveRequests);
            }
        }

        public void AddLeaveRequest(LeaveViewModel model)
        {
            var leaveRequestsList = LeaveRequests;
            leaveRequestsList.Add(model);
            _httpContextAccessor.HttpContext.Session.SetString("LeaveRequests", JsonSerializer.Serialize(leaveRequestsList));            
        }
    }
}
