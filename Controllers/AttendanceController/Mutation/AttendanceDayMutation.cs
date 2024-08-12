using HR_Management_System.Data;
using HR_Management_System.Models.AttendanceModel;

namespace HR_Management_System.Controllers.AttendanceController.Mutation
{
    [ExtendObjectType(Name = "EmployeeMutation")]
    public class AttendanceDayMutation
    {
        // Resolver to add New date in attendance.
        public async Task<AttendanceDay> AddAttendanceDay(AttendanceDay input, [Service] HRDBContext context)
        {
            var attendanceDay = new AttendanceDay
            {
                AttendanceDayDate = input.AttendanceDayDate
            };
            context.AttendanceDays.Add(attendanceDay);
            await context.SaveChangesAsync();
            return attendanceDay;
        }
    }
}