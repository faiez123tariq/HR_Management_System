using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.RecruitmentModel
{
    public class Interviews
    {
        [Key]
        public int InterviewID { get; set; }

        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Applications Application { get; set; }

        public int InterviewerId { get; set; }

        [ForeignKey("InterviewerId")]
        public Interviewers Interviewer { get; set; }

        public DateOnly InterviewDate { get; set; }
        public string InterviewFeedback { get; set; }

        [StringLength(10)]
        public string InterviewOutcome { get; set; }
    }
}