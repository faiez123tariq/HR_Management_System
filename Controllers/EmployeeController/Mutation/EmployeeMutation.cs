using HR_Management_System.Data;
using HR_Management_System.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace HR_Management_System.Controllers.EmployeeController.Mutation
{


    public class EmployeeMutation
    {




        // DBContext and ImageService dependency injection.
        private readonly HRDBContext _context;
        private readonly ImageService _imageService;
        public EmployeeMutation(HRDBContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }







        // Resolver to add Employee with image upload.
        public async Task<Employees> AddEmployee(IFile? file, Employees input)
        {

            string imageString = await _imageService.UploadImageAsync(file);
            var employee = new Employees
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                HireDate = input.HireDate,
                DateOfBirth = input.DateOfBirth,
                Gender = input.Gender,
                Email = input.Email,
                Nationality = input.Nationality,
                MaritalStatus = input.MaritalStatus,
                EmploymentStatus = input.EmploymentStatus,
                HomeContactPhone = input.HomeContactPhone,
                EmergencyContactPhone = input.EmergencyContactPhone,
                PersonalContactPhone = input.PersonalContactPhone,
                country = input.country,
                state = input.state,
                postalCode = input.postalCode,
                City = input.City,
                street = input.street,
                SalaryId = input.SalaryId,
                DeptId = input.DeptId,
                JobId = input.JobId,
                Photo = imageString
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }







        // Resolver to update Employee with image upload.
        public async Task<Employees> UpdateEmployee(IFile? newFile, Employees input)
        {
            var employee = await _context.Employees.FindAsync(input.EmployeeId);
            if (employee == null)
            {
                throw new GraphQLException($"Employee with ID {input.EmployeeId} not found.");
            }

            if (newFile != null)
            {
                string newImageUrl = await _imageService.UploadImageAsync(newFile);
                if (!string.IsNullOrEmpty(employee.Photo))
                {
                    await _imageService.DeleteImageAsync(employee.Photo);
                }
                employee.Photo = newImageUrl;
            }

            employee.FirstName = input.FirstName ?? employee.FirstName;
            employee.LastName = input.LastName ?? employee.LastName;
            employee.HireDate = input.HireDate != default ? input.HireDate : employee.HireDate;
            employee.DateOfBirth = input.DateOfBirth != default ? input.DateOfBirth : employee.DateOfBirth;
            employee.Gender = input.Gender ?? employee.Gender;
            employee.Email = input.Email ?? employee.Email;
            employee.Nationality = input.Nationality ?? employee.Nationality;
            employee.MaritalStatus = input.MaritalStatus ?? employee.MaritalStatus;
            employee.EmploymentStatus = input.EmploymentStatus ?? employee.EmploymentStatus;
            employee.HomeContactPhone = input.HomeContactPhone ?? employee.HomeContactPhone;
            employee.EmergencyContactPhone = input.EmergencyContactPhone ?? employee.EmergencyContactPhone;
            employee.PersonalContactPhone = input.PersonalContactPhone ?? employee.PersonalContactPhone;
            employee.country = input.country ?? employee.country;
            employee.state = input.state ?? employee.state;
            employee.postalCode = input.postalCode ?? employee.postalCode;
            employee.City = input.City ?? employee.City;
            employee.street = input.street ?? employee.street;
            employee.SalaryId = input.SalaryId ?? employee.SalaryId;
            employee.DeptId = input.DeptId ?? employee.DeptId;
            employee.JobId = input.JobId ?? employee.JobId;

            await _context.SaveChangesAsync();
            return employee;
        }








        // Resolver to Delete the Employee.
        public async Task<Employees> DeleteEmployeeAsync(int ID)
        {
            var employee = await _context.Employees
                                         .Include(e => e.Department)
                                         .FirstOrDefaultAsync(e => e.EmployeeId == ID);

            if (employee != null)
            {
                var departments = await _context.Departments
                                                .Where(d => d.DepartmentHeadId == ID)
                                                .ToListAsync();

                foreach (var department in departments)
                {
                    department.DepartmentHeadId = null;
                    _context.Departments.Update(department);
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                if (!string.IsNullOrEmpty(employee.Photo))
                {
                    await _imageService.DeleteImageAsync(employee.Photo);
                }
                return employee;
            }
            else
            {
                throw new GraphQLException($"Employee with ID {ID} not found.");
            }
        }




    }
}
