using HR_Management_System.Data;
using HR_Management_System.Models.AttendanceModel;

namespace HR_Management_System.Controllers.AttendanceController.Query
{
    [ExtendObjectType(Name = "EmployeeQuery")]
    public class AttendanceRecordsQuery
    {
        // Resolver to get all the attendance records
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AttendanceRecords> GetAttendanceRecords([Service] HRDBContext _context)
        {
            return _context.AttendanceRecords;
        }
    }
}