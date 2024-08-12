using HR_Management_System.Data;
using HR_Management_System.Models.AttendanceModel;

namespace HR_Management_System.Controllers.AttendanceController.Query
{
    [ExtendObjectType(Name = "EmployeeQuery")]
    public class LeaveRequestsQuery
    {
        // Reolver to get all the leave requests
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<LeaveRequests> GetLeaveRequests([Service] HRDBContext _context)
        {
            return _context.LeaveRequests;
        }
    }
}