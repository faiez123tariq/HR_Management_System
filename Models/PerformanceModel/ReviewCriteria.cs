using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.PerformanceModel
{
    public class ReviewCriteria
    {
        [Key]
        public int CriteriaID { get; set; }
        public string CriteriaName { get; set; }
        public string Description { get; set; }
        public ICollection<ReviewScores> ReviewScores { get; set; }
    }
}
