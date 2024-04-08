using EmpManage.Core.Entities;
using EmpManage.Core.Repositories;
using EmpManage.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            if (employee.EmployeePositions != null && employee.EmployeePositions.Any())
            {
                foreach (var employeePosition in employee.EmployeePositions)
                {
                    if (employeePosition.DateOfEntrance < employee.StartOfWork)
                    {
                        return null; 
                    }
                }
                var duplicatePositions = employee.EmployeePositions
                    .GroupBy(ep => ep.PositionId)
                    .Any(group => group.Count() >= 2);

                if (duplicatePositions)
                {
                    return null;
                }
            }
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> LogicalDeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.LogicalDeleteEmployeeAsync(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            if (employee.EmployeePositions != null && employee.EmployeePositions.Any())
            {
                foreach (var employeePosition in employee.EmployeePositions)
                {
                  
                    if (employeePosition.DateOfEntrance < employee.StartOfWork)
                    {
                        return null; 
                    }
                }
                var duplicatePositions = employee.EmployeePositions
                    .GroupBy(ep => ep.PositionId)
                    .Any(group => group.Count() >= 2);

                if (duplicatePositions)
                {
                    return null;
                }
            }
            return await _employeeRepository.UpdateEmployeeAsync(id, employee);
        }


    }
}
