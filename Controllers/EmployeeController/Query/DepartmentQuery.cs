using HR_Management_System.Data;

namespace HR_Management_System.Controllers.EmployeeController
{
    [ExtendObjectType(Name = "EmployeeQuery")]
    public class DepartmentQuery
    {
        // Resolver to get all departments.
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Department> GetDepartments([Service] HRDBContext _context)
        {
            return _context.Departments;
        }
    }
}