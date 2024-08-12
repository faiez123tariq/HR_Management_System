using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.PayrollModel
{
    public class Payrolls
    {
        [Key]
        public int PayrollId { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }

        public int SalaryId { get; set; }

        [ForeignKey("SalaryId")]
        public Salaries Salaries { get; set; }

        public int DeductionId { get; set; }

        [ForeignKey("DeductionId")]
        public Deductions Deductions { get; set; }

        public int BonusId { get; set; }

        [ForeignKey("BonusId")]
        public Bonuses Bonuses { get; set; }

        public decimal TotalPay { get; set; }
        public int payrollMonthId { get; set; }

        [ForeignKey("payrollMonthId")]
        public MonthlyPayroll MonthlyPayroll { get; set; }
    }
}