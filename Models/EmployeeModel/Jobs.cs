using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.EmployeeModel
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }
    }
}