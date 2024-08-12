using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.PayrollModel
{
    public class Salaries
    {
        [Key]
        public int SalaryId { get; set; }

        public int BaseSalary { get; set; }
        public int PayFrequency { get; set; }
        public ICollection<Payrolls> Payrolls { get; set; }
    }
}