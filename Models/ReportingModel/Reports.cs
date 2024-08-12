using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.ReportingModel
{
    public class Reports
    {
        [Key]
        public int ReportID { get; set; }
        public int ReportCategoryId { get; set; }
        [ForeignKey("ReportCategoryId")]
        public ReportCategories ReportCategory { get; set; }
        public string ReportName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int GeneratedBy { get; set; }
        public string Data { get; set; }
    }
}
