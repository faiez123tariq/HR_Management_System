
using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.AttendanceModel
{
    public class LeaveRequests
    {
        [Key]
        public int LeaveRequestID { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employees Employee { get; set; }
        public string LeaveType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
    }
}
