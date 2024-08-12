using HR_Management_System.Data;
using HR_Management_System.Models.EmployeeModel;

namespace HR_Management_System.Controllers.EmployeeController.Mutation
{

    [ExtendObjectType(Name = "EmployeeMutation")]
    public class DepartmentMutation
    {

        // Resolver to add Department.
        public async Task<Department> AddDepartment([Service] HRDBContext _context, Department input)
        {
            var department = new Department
            {
                DeptName = input.DeptName,
                DepartmentHeadId = input.DepartmentHeadId
            };
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }




        // Resolver to update Department.
        public async Task<Department> UpdateDepartment(Department input, [Service] HRDBContext _context)
        {
            var department = await _context.Departments.FindAsync(input.DepartmentId);
            if (department == null)
            {
                throw new GraphQLException($"Department with ID {input.DepartmentId} not found.");
            }
            department.DeptName = input.DeptName ?? department.DeptName;
            department.DepartmentHeadId = input.DepartmentHeadId ?? department.DepartmentHeadId;
            await _context.SaveChangesAsync();
            return department;
        }





        // Resolver to Delete the Department.
        public async Task<Department> DeleteDepartmentAsync(int ID, [Service] HRDBContext _context)
        {
            try
            {
                var department = await _context.Departments.FindAsync(ID);
                if (department == null)
                {
                    throw new GraphQLException($"Department with ID {ID} not found.");
                }
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return department;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(ex.Message);
            }
        }




    }
}
