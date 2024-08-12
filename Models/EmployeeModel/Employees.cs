using HR_Management_System.Models.AttendanceModel;
using HR_Management_System.Models.BenefitsModel;
using HR_Management_System.Models.PayrollModel;
using HR_Management_System.Models.PerformanceModel;
using HR_Management_System.Models.RecruitmentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management_System.Models.EmployeeModel
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        public DateOnly HireDate { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [StringLength(15)]
        public string Gender { get; set; }
        [StringLength(320)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(15)]
        public string MaritalStatus { get; set; }
        [Required]
        [StringLength(15)]
        public string EmploymentStatus { get; set; }
        public string Photo { get; set; }
        [StringLength(30)]
        public string HomeContactPhone { get; set; }
        [StringLength(30)]
        public string EmergencyContactPhone { get; set; }
        [StringLength(30)]
        public string PersonalContactPhone { get; set; }
        [Required]
        public string country { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string postalCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string street { get; set; }
        public int? SalaryId { get; set; }
        [ForeignKey("SalaryId")]
        public Salaries salary { get; set; }
        public int? DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }
        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public Jobs Job { get; set; }

        public ICollection<Payrolls> Payrolls { get; set; }
        public ICollection<TrackHistory> TrackHistories { get; set; }
        public ICollection<JobOpenings> JobOpenings { get; set; }
        public ICollection<Interviewers> Interviewers { get; set; }
        public ICollection<AttendanceRecords> AttendanceRecords { get; set; }
        public ICollection<LeaveRequests> LeaveRequests { get; set; }
        public ICollection<PerformanceReviews> PerformanceReviews { get; set; }
        public ICollection<PerformanceReviews> ReviewsGiven { get; set; }
        public ICollection<EmployeeBenefits> EmployeeBenefits { get; set; }
    }


}




