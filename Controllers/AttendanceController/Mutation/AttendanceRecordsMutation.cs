using HR_Management_System.Data;
using HR_Management_System.Models.AttendanceModel;

namespace HR_Management_System.Controllers.AttendanceController.Mutation
{
    [ExtendObjectType(Name = "EmployeeMutation")]
    public class AttendanceRecordsMutation
    {
        // Resolver to add a new attendance record
        public async Task<AttendanceRecords> AddAttendanceRecordAsync(AttendanceRecords input, [Service] HRDBContext context)
        {
            var attendanceRecord = new AttendanceRecords
            {
                EmployeeId = input.EmployeeId,
                Status = input.Status,
                AttendanceDayId = input.AttendanceDayId,
                CheckInTime = input.CheckInTime,
                CheckOutTime = input.CheckOutTime
            };
            context.AttendanceRecords.Add(attendanceRecord);
            await context.SaveChangesAsync();
            return attendanceRecord;
        }
    }
}