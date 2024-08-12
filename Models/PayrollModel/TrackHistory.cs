using HR_Management_System.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.PayrollModel
{
    public class TrackHistory
    {
        [Key]
        public int HistoryId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }
        public decimal ChangeAmount { get; set; }
        public string ChangeReason { get; set; }
        public DateOnly EffectiveDate { get; set; }

    }
}
