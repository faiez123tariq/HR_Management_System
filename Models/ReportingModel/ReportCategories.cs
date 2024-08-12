using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Models.ReportingModel
{
    public class ReportCategories
    {
        [Key]
        public int ReportCategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Reports> Reports { get; set; }
    }
}
