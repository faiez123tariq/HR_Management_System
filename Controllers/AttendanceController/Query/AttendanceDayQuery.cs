using HR_Management_System.Data;
using HR_Management_System.Models.AttendanceModel;

namespace HR_Management_System.Controllers.AttendanceController.Query
{
    [ExtendObjectType(Name = "EmployeeQuery")]
    public class AttendanceDayQuery
    {
        // Reslover to get all attendance days.
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AttendanceDay> GetAttendanceDays([Service] HRDBContext _context)
        {
            return _context.AttendanceDays;
        }
    }
}