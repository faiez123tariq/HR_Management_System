using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.RecruitmentModel
{
    public class Applications
    {
        [Key]
        public int ApplicationID { get; set; }
        public int JobOpeningId { get; set; }
        [ForeignKey("JobOpeningId")]
        public JobOpenings JobOpening { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string Resume { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public string Status { get; set; }
        public Interviews Interviews { get; set; }
    }
}
