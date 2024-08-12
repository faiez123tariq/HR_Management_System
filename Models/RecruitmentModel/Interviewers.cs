using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.RecruitmentModel
{
    public class Interviewers
    {
        [Key]
        public int InterviewerID { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employees Employee { get; set; }
        public ICollection<Interviews> Interviews { get; set; }
    }
}
