using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.BenefitsModel
{
    public class EmployeeBenefits
    {
        [Key]
        public int EmployeeBenefitID { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employee { get; set; }

        public int BenefitId { get; set; }

        [ForeignKey("BenefitId")]
        public Benefits Benefit { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
    }
}