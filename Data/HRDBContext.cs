using HR_Management_System.Models.AttendanceModel;
using HR_Management_System.Models.BenefitsModel;
using HR_Management_System.Models.EmployeeModel;
using HR_Management_System.Models.PayrollModel;
using HR_Management_System.Models.PerformanceModel;
using HR_Management_System.Models.RecruitmentModel;
using HR_Management_System.Models.ReportingModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR_Management_System.Data
{
    public class HRDBContext : DbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Payrolls> Payrolls { get; set; }
        public DbSet<MonthlyPayroll> MonthlyPayrolls { get; set; }
        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<Deductions> Deductions { get; set; }
        public DbSet<Bonuses> Bonuses { get; set; }
        public DbSet<TrackHistory> TrackHistory { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Interviewers> Interviewers { get; set; }
        public DbSet<Interviews> Interviews { get; set; }
        public DbSet<JobOpenings> JobOpenings { get; set; }
        public DbSet<AttendanceDay> AttendanceDays { get; set; }
        public DbSet<AttendanceRecords> AttendanceRecords { get; set; }
        public DbSet<LeaveRequests> LeaveRequests { get; set; }
        public DbSet<Benefits> Benefits { get; set; }
        public DbSet<EmployeeBenefits> EmployeeBenefits { get; set; }
        public DbSet<PerformanceReviews> PerformanceReviews { get; set; }
        public DbSet<ReviewCriteria> reviewCriterias { get; set; }
        public DbSet<ReviewScores> ReviewScores { get; set; }
        public DbSet<ReportCategories> ReportCategories { get; set; }
        public DbSet<Reports> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        var maxLength = property.PropertyInfo
                                      .GetCustomAttributes(typeof(StringLengthAttribute), true)
                                      .OfType<StringLengthAttribute>()
                                      .FirstOrDefault()?.MaximumLength ?? 200;
                        property.SetColumnType($"VARCHAR({maxLength})");
                    }
                }
            }

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.PerformanceReviews)
                .WithOne(pr => pr.Employee)
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PerformanceReviews>()
                .HasOne(pr => pr.Reviewer)
                .WithMany()
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payrolls>()
                .HasOne(p => p.Deductions)
                .WithMany(d => d.Payrolls)
                .HasForeignKey(p => p.DeductionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payrolls>()
                .HasOne(p => p.Employees)
                .WithMany()
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payrolls>()
               .HasOne(p => p.Salaries)
               .WithMany()
               .HasForeignKey(p => p.SalaryId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payrolls>()
              .HasOne(p => p.Bonuses)
              .WithMany()
              .HasForeignKey(p => p.BonusId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payrolls>()
              .HasOne(p => p.MonthlyPayroll)
              .WithMany()
              .HasForeignKey(p => p.payrollMonthId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Interviews>()
             .HasOne(p => p.Interviewer)
             .WithMany()
             .HasForeignKey(p => p.InterviewerId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
             .HasOne(d => d.DepartmentHead)
             .WithMany()
             .HasForeignKey(d => d.DepartmentHeadId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DeptId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }

}
