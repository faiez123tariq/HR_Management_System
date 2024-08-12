using HR_Management_System.Data;
using HR_Management_System.Models.EmployeeModel;

namespace HR_Management_System.Controllers.EmployeeController
{
    public class EmployeeQuery
    {
        // Function to get all the employees with optional pagination
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Employees> GetEmployees([Service] HRDBContext _context, int? skip, int? take)
        {
            var query = _context.Employees.AsQueryable();
            if (take.HasValue && take.Value > 0)
            {
                query = query.Skip(skip.Value).Take(take.Value);
            }
            return query;
        }
    }
}