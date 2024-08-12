using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.PerformanceModel
{
    public class PerformanceReviews
    {
        [Key]
        public int ReviewID { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employee { get; set; }

        public int ReviewerId { get; set; }

        [ForeignKey("ReviewerId")]
        public Employees Reviewer { get; set; }

        public DateOnly ReviewDate { get; set; }
        public int OverallScore { get; set; }
        public string Comments { get; set; }
        public ICollection<ReviewScores> ReviewScores { get; set; }
    }
}