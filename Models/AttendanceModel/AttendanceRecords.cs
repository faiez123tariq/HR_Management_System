using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.AttendanceModel
{
    public class AttendanceRecords
    {
        [Key]
        public int AttendanceID { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employee { get; set; }

        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public int AttendanceDayId { get; set; }

        [ForeignKey("AttendanceDayId")]
        public AttendanceDay AttendanceDay { get; set; }
    }
}