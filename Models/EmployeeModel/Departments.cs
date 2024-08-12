using HR_Management_System.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [StringLength(50)]
    public string DeptName { get; set; }

    public int? DepartmentHeadId { get; set; }

    [ForeignKey("DepartmentHeadId")]
    public Employees DepartmentHead { get; set; }

    public ICollection<Employees> Employees { get; set; }
}