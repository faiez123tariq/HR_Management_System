using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.PerformanceModel
{
    public class ReviewScores
    {
        [Key]
        public int ScoreID { get; set; }
        public int ReviewId { get; set; }
        [ForeignKey("ReviewId")]
        public PerformanceReviews PerformanceReview { get; set; }
        public int CriteriaId { get; set; }
        [ForeignKey("CriteriaId")]
        public ReviewCriteria ReviewCriteria { get; set; }
        public int Score { get; set; }
    }
}
