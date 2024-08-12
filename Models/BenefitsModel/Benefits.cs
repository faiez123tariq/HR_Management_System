using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.BenefitsModel
{
    public class Benefits
    {
        [Key]
        public int BenefitId { get; set; }
        public string BenefitName { get; set; }
        public string Description { get; set; }
        public string EligibilityCriteria { get; set; } // e.g., "Full-Time", "Part-Time"
        public ICollection<EmployeeBenefits> EmployeeBenefits { get; set; }
    }
}
