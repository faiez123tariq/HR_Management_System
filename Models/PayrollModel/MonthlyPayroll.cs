using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.PayrollModel
{
    public class MonthlyPayroll
    {
        [Key]
        public int Id { get; set; }

        public DateOnly PayrollMonth { get; set; }
    }
}