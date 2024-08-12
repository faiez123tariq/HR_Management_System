using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.PayrollModel
{
    public class Deductions
    {
        [Key]
        public int DeductionId { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }

        public decimal DeductionAmount { get; set; }
        public string DeductionReason { get; set; }
        public DateOnly DeductionDate { get; set; }
        public ICollection<Payrolls> Payrolls { get; set; }
    }
}