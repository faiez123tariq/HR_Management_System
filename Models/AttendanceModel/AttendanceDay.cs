using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.AttendanceModel
{
    public class AttendanceDay
    {
        [Key]
        public int AttendanceDayId { get; set; }

        public DateOnly AttendanceDayDate { get; set; }
    }
}