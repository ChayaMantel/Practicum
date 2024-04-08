using EmpManage.Core.Entities;
using EmpManage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {

            await _dataContext.Employees.AddAsync(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dataContext.Employees.Remove(employee);
                await _dataContext.SaveChangesAsync();
            }
            await _dataContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dataContext.Employees.Include(e => e.EmployeePositions).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dataContext.Employees.Include(e => e.EmployeePositions).FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<Employee> LogicalDeleteEmployeeAsync(int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Active = false;
            }
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existEmployee = await _dataContext.Employees
                .Include(e => e.EmployeePositions)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (existEmployee != null)
            {
                existEmployee.Identity = employee.Identity;
                existEmployee.FirstName = employee.FirstName;
                existEmployee.LastName = employee.LastName;
                existEmployee.StartOfWork = employee.StartOfWork;
                existEmployee.BirthDate = employee.BirthDate;
                existEmployee.Gender = employee.Gender;
                existEmployee.Active = employee.Active;
                existEmployee.EmployeePositions = employee.EmployeePositions;


                await _dataContext.SaveChangesAsync();
            }

            return existEmployee;
        }

    }
}
