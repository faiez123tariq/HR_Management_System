using HR_Management_System.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.RecruitmentModel
{
    public class JobOpenings
    {
        [Key]
        public int JobOpeningID { get; set; }

        public int JobTitleId { get; set; }

        [ForeignKey("JobTitleId")]
        public Jobs Jobs { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Departments { get; set; }

        public DateOnly OpenDate { get; set; }
        public DateOnly CloseDate { get; set; }
        public string JobDescription { get; set; }
        public ICollection<Applications> Applications { get; set; }
    }
}