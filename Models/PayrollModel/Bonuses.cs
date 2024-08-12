using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.PayrollModel
{
    public class Bonuses
    {
        [Key]
        public int BonusId { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }

        public decimal BonusAmount { get; set; }
        public string BonusReason { get; set; }
        public DateOnly BonusDate { get; set; }
        public ICollection<Payrolls> Payrolls { get; set; }
    }
}